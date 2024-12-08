using Sunny.UI;
using WFAI.Utils.Net.HttpEx;
using WFAI.Utils.Net.Pojo;


namespace WFAI.Page
{
    public partial class UserChatPage : UIPage
    {
        public UserChatPage()
        {
            InitializeComponent();
            lvMsgData.DrawMode = DrawMode.OwnerDrawVariable;
            lvMsgData.DrawItem += lvMsgDataListBox_DrawItem;
            lvMsgData.MeasureItem += lvMsgDataListBox_MeasureItem;
        }

        private void lvMsgDataListBox_MeasureItem(object? sender, MeasureItemEventArgs e)
        {
            // 使用 Graphics.MeasureString 计算文本高度
            using (Graphics g = lvMsgData.CreateGraphics())
            {
                string? itemText = lvMsgData.Items[e.Index].ToString();
                SizeF stringSize = g.MeasureString(itemText, lvMsgData.Font, lvMsgData.Width - 2 * SystemInformation.VerticalScrollBarWidth); // 减去滚动条宽度
                e.ItemHeight = (int)stringSize.Height;
            }
        }

        private void lvMsgDataListBox_DrawItem(object? sender, DrawItemEventArgs e)
        {
            // 绘制背景
            e.DrawBackground();

            // 绘制文本，使用 TextRenderer.DrawText 实现自动换行
            string? itemText = lvMsgData.Items[e.Index].ToString();
            Rectangle textBounds = e.Bounds;

            //  缩小textBounds，为边框留出空间
            textBounds.Inflate(-2, -2);

            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordBreak;
            TextRenderer.DrawText(e.Graphics, itemText, lvMsgData.Font, textBounds, e.ForeColor, flags);

            // 绘制选中状态
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.DrawFocusRectangle();
            }
        }

        public override void Init()
        {
            InitOther();
        }

        private void InitOther()
        {


        }
        
        #region 输入框部分
        string ConversationID;

        private void TxtInputMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnSendMsg.Enabled)
                {
                    SendInputMsgToServer();
                }
                else
                {
                    UIMessageTip.Show("对话未完成");
                }
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            SendInputMsgToServer();

        }

        private async void SendInputMsgToServer()
        {
            btnSendMsg.Enabled = false;
            string msg = txtInputMsg.Text.Trim();
            if (msg.Length == 0)
            {
                UIMessageTip.Show("不能输入空白信息");
                return;
            }
            try
            {
                //初始化连接
                //var res = HttpEx.GetAsync<string>(APIEx.ChatAIBaseChatURL);
                //var res =  await HttpClientEx.GetAsync<string,string>(APIEx.ChatAIBaseChatURL);
                //var res =  await HttpClientEx.GetAsync<string>(APIEx.ChatAIBaseURL);
                AddMsgItemTolvMsgData($"[用户]:{msg}");
                txtInputMsg.Text = "";
                var req = new ReqDifyChatMessage(msg, DifyRsponseMode.Blocking);
                req.conversation_id = ConversationID;
                var res = await DifyChatClientEx.SendChatMessageAsync<ReqDifyChatMessage, RspDifyChatMessage>(req);
                //var rsp = await DifyChatClientEx.SendChatMessageAsync<ReqDifyChatMessage>(APIEx.JdfyChatAPIKey, req);
                //var res = await DifyChatClientEx.HandleStreamingResponse(rsp);
                Console.WriteLine($"输出的内容：{res}");
                //UIMessageBox.Show("输出：" + res.answer);
                if (res != null)
                {
                    AddMsgItemTolvMsgData(res);
                    if (!string.IsNullOrEmpty(res.conversation_id))
                    {
                        ConversationID = res.conversation_id;
                    }
                }
            }
            catch (Exception ex)
            {
                UIMessageBox.Show($"发送错误:{ex.Message}");
                btnSendMsg.Enabled = true;
            }
            finally
            {
                btnSendMsg.Enabled = true;
            }
        }
        #endregion

        #region lvMsgData
        private void AddMsgItemTolvMsgData(RspDifyChatMessage rspDify)
        {
            var data = new UserChatData()
            {
                MessageID = rspDify.message_id,
                Message = rspDify.answer,
                UserName = rspDify.Event,
                ConversationID = rspDify.conversation_id,
            };
            AddMsgItemTolvMsgData(data.ToString());
        }

        private void AddMsgItemTolvMsgData(string text)
        {
            lvMsgData.Items.Add(text);
            //lvMsgData.Refresh();
        }
        #endregion

        #region 设置
        private void lbSetting_Click(object sender, EventArgs e)
        {
            UIMessageBox.Show($"暂未实现");
        }

        #endregion
    }
}
