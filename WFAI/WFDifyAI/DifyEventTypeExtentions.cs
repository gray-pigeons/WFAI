using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFAI.Utils.Net.Pojo;

namespace WFAI.WFDifyAI
{
    internal static class DifyEventTypeExtentions
    {
        public static DifyEventType GetDifyEventType(this string eventType)
        {
            switch (eventType)
            {
                case "message":
                    return DifyEventType.Message;
                case "agent_message":
                    return DifyEventType.AgentMessage;
                case "agent_thought":
                    return DifyEventType.AgentThought;
                case "message_file":
                    return DifyEventType.MessageFile;
                case "message_end ":
                    return DifyEventType.MessageEnd;
                case "tts_message":
                    return DifyEventType.TtsMessage;
                case "tts_message_end":
                    return DifyEventType.TtsMessageEnd;
                case " message_replace":
                    return DifyEventType.MessageRplace;
                case "error ":
                    return DifyEventType.Error;
                case " ping ":
                    return DifyEventType.Ping;
                default:
                    return DifyEventType.None;
            }

        }

        public static string GetDifyRsponseModeStr(this DifyRsponseMode difyRsponseMode)
        {
            if (difyRsponseMode == DifyRsponseMode.Streaming)
            {
              return "streaming";
            }
            else if (difyRsponseMode == DifyRsponseMode.Blocking)
            {
                return "blocking";
            }
            else
            {
                return "";
            }
        }
    }
}
