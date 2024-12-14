using DifyAI.ObjectModels;
using Masuit.Tools;
using Masuit.Tools.Systems;
using Sunny.UI;
using WFAI.Utils.Net.HttpEx;
using WFAI.Utils.Net.Pojo;
using WFAI.WFDifyAI;
using WFAI.WFDifyAI.ChatMessage;


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
                DifyChatMessages DifyChat = new DifyChatMessages();
                AddMsgItemTolvMsgData($"[用户]:{msg}");
                txtInputMsg.Text = "";
                //await SendDifyChatMessage(msg);
                //await SendOllamaChatMessage(msg);
                //await SendBlockDifyAIChatMsg(DifyChat);
                await SendStreamDifyAIChatMsg(DifyChat, msg);
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

        private async Task SendStreamDifyAIChatMsg(DifyChatMessages DifyChat, string msg)
        {
            var req = new ChatCompletionRequest()
            {
                Query = msg,
                User = "user123",
                Inputs = new Dictionary<string, string>
                {
                    ["arg1"] = "1",
                    ["arg2"] = "2",
                },
            };
            //await DifyChat.SendStreamChatMsg(req);
            var data = new UserChatData()
            {
                MessageID = string.Empty,
                Message = string.Empty,
                UserName = string.Empty,
                ConversationID = string.Empty,
            };
            await DifyChat.SendStreamChatMsg(req, (rsp) =>
            {
                if (rsp != null)
                {
                    var eventTpye = rsp.Event.GetDifyEventType();

                    if (eventTpye == DifyEventType.Message)
                    {
                        ChunkCompletionMessageResponse? rspMsg = rsp as ChunkCompletionMessageResponse;
                        data.MessageID = rspMsg.MessageId;
                        data.Message += rspMsg.Answer;
                        data.UserName = string.Empty;
                        data.ConversationID = rspMsg.ConversationId;
                    }
                    else if (eventTpye == DifyEventType.MessageEnd)
                    {
                        ChunkCompletionMessageEndResponse? rspMsg = rsp as ChunkCompletionMessageEndResponse;
                        data.MessageID = rspMsg.MessageId;
                        //data.Message = rspMsg.TaskId;
                        data.UserName = string.Empty;
                        data.ConversationID = rspMsg.ConversationId;
                    }
                    AddMsgItemToLastlvMsgData(data.ToString());
                }
            });
        }
        #endregion

        #region DifyAI



        #endregion


        #region 自己的发送消息到聊天服务器
        private async Task SendOllamaChatMessage(string msg)
        {
            var request = new LocalOllamaChatMessageReq()
            {
                PromptMessage = msg,
                Model = LocalOllamaChatClientEx.localOllamaChatConfigData.ModelValue,
                Stream = false,
            };
            var res = await LocalOllamaChatClientEx.SendChatMessageAsync<LocalOllamaChatMessageReq, LocalOllamaChatMessageRsp>(request);
            if (res != null)
            {
                var data = new UserChatData()
                {
                    MessageID = string.Empty,
                    Message = res.Response,
                    UserName = string.Empty,
                    ConversationID = string.Empty,
                };
                AddMsgItemTolvMsgData(data.ToString());
            }
        }

        private async Task SendDifyChatMessage(string msg)
        {
            var req = new ReqDifyChatMessage(msg, DifyRsponseMode.Blocking);
            req.conversation_id = ConversationID;
            var res = await DifyChatClientEx.SendChatMessageAsync<ReqDifyChatMessage, RspDifyChatMessage>(req);
            //var rsp = await DifyChatClientEx.SendChatMessageAsync<ReqDifyChatMessage>(APIEx.JdfyChatAPIKey, req);
            //var res = await DifyChatClientEx.HandleStreamingResponse(rsp);
            Console.WriteLine($"输出的内容：{res}");
            //UIMessageBox.Show("输出：" + res.answer);
            if (res != null)
            {
                var data = new UserChatData()
                {
                    MessageID = res.message_id,
                    Message = res.answer,
                    UserName = res.Event,
                    ConversationID = res.conversation_id,
                };
                AddMsgItemTolvMsgData(data.ToString());
                if (!string.IsNullOrEmpty(res.conversation_id))
                {
                    ConversationID = res.conversation_id;
                }
            }
        }
        #endregion

        #region lvMsgData

        Dictionary<int, UserChatData> m_lvMsgDataDic = new Dictionary<int, UserChatData>();
        private void AddMsgItemToLastlvMsgData(string text)
        {
           var data = lvMsgData.Items[lvMsgData.Items.Count - 1];
            //UIMessageBox.Show(data.ToJsonString());
            //todo 
            int index = lvMsgData.Items.Count - 1;
            if (index>0)
            {
                lvMsgData.Items.RemoveAt(index);
            }
            AddMsgItemTolvMsgData(text);
        }

        private void AddMsgItemTolvMsgData(string text)
        {
            lvMsgData.Items.Add(text);
            //lvMsgData.Refresh();
            //lvMsgData.HorizontalScrollbar
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
