

using CSharpUtils.DifyAI.Const;

namespace CSharpUtils.DifyAI.Extension
{
    public static class DifyEventTypeExtension
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
