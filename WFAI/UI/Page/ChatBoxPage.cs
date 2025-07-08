using AntdUI.Chat;
using CSharpUtils.DifyAI;
using CSharpUtils.DifyAI.ChatMessage;
using CSharpUtils.DifyAI.Extension;
using DifyAI.ObjectModels;
using Masuit.Tools;
using Sunny.UI;
using WFAI.Utils.Net.Pojo;
using WFAI.Utils.Tools.IniEx;

namespace WFAI.Page
{
    public partial class ChatBoxPage : UIPage
    {
        public ChatBoxPage()
        {
            InitializeComponent();
            Init();
        }

        


        public override void Init()
        {
            InitOther();
        }



        IniDifyChatConfigData difyChatConfigData;
        DifyAIChatMessages difyChat;

        private void InitOther()
        {
            difyChatConfigData = new IniDifyChatConfigData()
            {
                Section = IniConfigConst.DifyServerSection,
                KeyParameter = IniConfigConst.DifyServerAddr,
                KeyVal = "https://jdify.667374.xyz/v1",
                //KeyVal = "http://159.112.186.46:8090/v1",
                APIKeyParameter = IniConfigConst.DifyQwenServerApiKey,
                APIKeyValue = "app-RlDcoVWSpbvdvmWLTbHT53Or",
                //APIKeyValue = "app-lwXtmR4MWJrqctdrA6YuO6d1",
                //APIKeyValue = "app-lwXtmR4MWJrqctdrA6YuO6d1",//frp
                UserParams = IniConfigConst.DifyUser,
                UserValue = "0a68eb57"
            };
            var (isOk, _) =IniEx. GetDifyIniConfigData(difyChatConfigData);
            if (!isOk)
            {
                throw new NullReferenceException("未读取到配置数据");
            }
            //difyChatConfigData.APIKeyValue = "app-8Vae535bz9qWZfquzfCeN15b";
            difyChat = new DifyAIChatMessages(difyChatConfigData.KeyVal,difyChatConfigData.APIKeyValue,"");

        }

        private async void InitLoadHistoryInfo()
        {
            var req = new MessageHistoryRequest();
            req.User = "user123";
            req.ApiKey = difyChatConfigData.APIKeyValue;
            //req.FirstId
           var rsp = await difyChat.GetHistoryInfo(req);
            if (rsp != null&& rsp.Data!=null) 
            {
                foreach (var item in rsp.Data)
                {
                    var data = new UserChatData()
                    {
                        MessageID = item.Id,
                        Message = item.Answer,
                        UserName = item.Query,
                        ConversationID = item.ConversationId,
                        TaskID = string.Empty,
                    };

                    AddMsgItemToLeftlvMsgData(data);
                }
            }
            UIMessageBox.Show($"{rsp.ToJsonString()}");
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
            //InitLoadHistoryInfo();

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
                var data = new UserChatData()
                {
                    MessageID = string.Empty,
                    Message = msg,
                    UserName = "用户",
                    ConversationID = string.Empty,
                    TaskID = string.Empty,
                };

                AddMsgItemToLastlvMsgData(data,true);
                txtInputMsg.Text = "";
                await SendStreamDifyAIChatMsg(difyChat, msg);
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

        private async Task SendStreamDifyAIChatMsg(DifyAIChatMessages DifyChat, string msg)
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
            var data = new UserChatData()
            {
                MessageID = string.Empty,
                Message = string.Empty,
                UserName = string.Empty,
                ConversationID = string.Empty,
                TaskID = string.Empty,
            };
            await Task.Run(async () => 
            {
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
                            data.TaskID = rspMsg.TaskId;
                            data.ConversationID = rspMsg.ConversationId;
                        }
                        else if (eventTpye == DifyEventType.MessageEnd)
                        {
                            ChunkCompletionMessageEndResponse? rspMsg = rsp as ChunkCompletionMessageEndResponse;
                            data.MessageID = rspMsg.MessageId;
                            data.TaskID = rspMsg.TaskId;
                            data.ConversationID = rspMsg.ConversationId;
                        }
                        data.UserName = "AI";
                        this.BeginInvoke(() => 
                        {
                            AddMsgItemToLeftlvMsgData(data);
                        });
                    }
                });
            });
            
        }

        #endregion

        #region lvMsgData

        List<TextChatItem> m_lvMsgDataList = new();
        List<UserChatData> m_lvMsgUserDataList = new();

        private void AddMsgItemToLastlvMsgData(UserChatData data,bool isMe)
        {
            var textChatItem = new TextChatItem(data.ToString());
            textChatItem.Me = isMe;
            textChatItem.Icon = data.HeadIcon;
            textChatItem.Name = data.UserName;
            m_lvMsgUserDataList.Add(data);
            AddToChatView(textChatItem);
        }

        private void AddMsgItemToLeftlvMsgData(UserChatData data)
        {
            var textChatItem = new TextChatItem(data.ToString());
            textChatItem.Me = false;
            textChatItem.Icon = data.HeadIcon;
            textChatItem.Name = data.UserName;
            //lvChatMsgList.Items.Add(textChatItem);
            int index = m_lvMsgUserDataList.Count - 1;
            if (m_lvMsgUserDataList.Count > 0 && m_lvMsgUserDataList[index].TaskID == data.TaskID)
            {
                m_lvMsgUserDataList.RemoveAt(index);
                m_lvMsgDataList.RemoveAt(index);
                lvChatMsgList.Items.RemoveAt(index);
            }
            m_lvMsgUserDataList.Add(data);
            AddToChatView(textChatItem);
        }

        void AddToChatView(TextChatItem data)
        {
            m_lvMsgDataList.Add(data);
            lvChatMsgList.AddToBottom(data);
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
