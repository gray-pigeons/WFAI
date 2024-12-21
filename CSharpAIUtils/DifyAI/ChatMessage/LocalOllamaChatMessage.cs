using Newtonsoft.Json;

namespace CSharpUtils.DifyAI.ChatMessage
{
    internal class LocalOllamaChatMessage
    {

    }

    public class LocalOllamaChatMessageReq
    {
        [JsonProperty("prompt")]
        public required string PromptMessage { get; set; }
        [JsonProperty("model")]
        public required string Model { get; set; }
        [JsonProperty("stream")]
        public required bool Stream { get; set; } = false;
    }

    public class LocalOllamaChatMessageRsp
    {
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("response")]
        public string Response { get; set; }
        [JsonProperty("done")]
        public bool Done { get; set; }
        [JsonProperty("done_reason")]
        public string DoneReason { get; set; }
    }
}
