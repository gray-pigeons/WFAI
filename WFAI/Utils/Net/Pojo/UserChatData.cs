using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAI.Utils.Net.Pojo
{
    internal class UserChatData
    {
        public required string Message {  get; set; }
        public required  string MessageID { get; set; }
        public required  string TaskID { get; set; }

        public required string UserName { get; set; }

        /// <summary>
        /// 会话 ID，需要基于之前的聊天记录继续对话，必须传之前消息的 conversation_id。
        /// </summary>
        public required string ConversationID{ get; set; }

        public Bitmap HeadIcon { get; set; }


        public override string ToString()
        {
            return $"{Message}";
        }
    }
}
