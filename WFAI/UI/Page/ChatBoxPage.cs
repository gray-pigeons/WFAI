using AntdUI.Chat;
using CSharpUtils.DifyAI;
using CSharpUtils.DifyAI.ChatMessage;
using CSharpUtils.DifyAI.Extension;
using DifyAI.ObjectModels;
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
                KeyVal = string.Empty,
                APIKeyParameter = IniConfigConst.DifyQwenServerApiKey,
                APIKeyValue = string.Empty,
                UserParams = IniConfigConst.DifyUser,
                UserValue = string.Empty,
            };
            var (isOk, _) =IniEx. GetDifyIniConfigData(difyChatConfigData);
            if (!isOk)
            {
                throw new NullReferenceException("未读取到配置数据");
            }
            difyChat = new DifyAIChatMessages(difyChatConfigData.KeyVal,difyChatConfigData.APIKeyValue,"");
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
