using CSharpUtils.DifyAI.Const;
using Newtonsoft.Json;


namespace CSharpUtils.DifyAI.ChatMessage
{

    #region 发送聊天消息

    public class ReqDifyChatMessage
    {
        public Dictionary<string, object> inputs { get; set; } = new(); // Or use a more specific type if known
        public string query { get; set; }//用户输入/提问内容。
        public string response_mode { get; set; } = "streaming";
        public string conversation_id { get; set; } = "";
        public string user { get; set; }
        //public List<FileDetails>? files { get; set; }

        public ReqDifyChatMessage(string query, DifyRsponseMode mode = DifyRsponseMode.Streaming)
        {
            this.query = query;
            //user = DifyChatClientEx.difyChatConfigData.UserValue;
            user = "DifyChatClientEx.difyChatConfigData.UserValue";
            if (mode == DifyRsponseMode.Streaming)
            {
                response_mode = "streaming";
            }
            else if (mode == DifyRsponseMode.Blocking)
            {
                response_mode = "blocking";
            }
        }

        public ReqDifyChatMessage(string query, string user, DifyRsponseMode mode = DifyRsponseMode.Streaming)
        {
            this.query = query;
            this.user = user;

            if (mode == DifyRsponseMode.Streaming)
            {
                response_mode = "streaming";
            }
            else if (mode == DifyRsponseMode.Blocking)
            {
                response_mode = "blocking";
            }
        }

        //public ChatMessage(string query, string user, string imageUrl)
        //{
        //    this.query = query;
        //    this.user = user;
        //    this.files = new List<FileDetails> { new FileDetails { type = "image", transfer_method = "remote_url", url = imageUrl } };

        //}

    }


    public class FileDetails
    {
        public string type { get; set; }
        public string transfer_method { get; set; }
        public string url { get; set; }
    }



    public class RspDifyChatMessage
    {
        [JsonProperty("event")]
        public string Event { get; set; }
        public string message_id { get; set; }
        public string conversation_id { get; set; }
        public string mode { get; set; }
        public string answer { get; set; }
        public Metadata metadata { get; set; }
        public long created_at { get; set; }


        // Helper property to get a DateTime object from the timestamp
        public DateTime CreatedAt => DateTimeOffset.FromUnixTimeSeconds(created_at).DateTime;

    }

    public class Metadata
    {
        public Usage usage { get; set; }
        public List<RetrieverResource> retriever_resources { get; set; }
    }

    public class Usage
    {
        public int prompt_tokens { get; set; }
        public string prompt_unit_price { get; set; }
        public string prompt_price_unit { get; set; }
        public string prompt_price { get; set; }  // Use string for prices to avoid precision issues
        public int completion_tokens { get; set; }
        public string completion_unit_price { get; set; }
        public string completion_price_unit { get; set; }
        public string completion_price { get; set; }  // Use string for prices
        public int total_tokens { get; set; }
        public string total_price { get; set; }   // Use string for prices
        public string currency { get; set; }
        public double latency { get; set; }
    }

    public class RetrieverResource
    {
        public int position { get; set; }
        public string dataset_id { get; set; }
        public string dataset_name { get; set; }
        public string document_id { get; set; }
        public string document_name { get; set; }
        public string segment_id { get; set; }
        public double score { get; set; }
        public string content { get; set; }
    }

    #endregion


    #region 获取聊天列表
    public class GetDifyHistoryChatDataListReq
    {
        /// <summary>
        /// 会话 ID
        /// </summary>
        public required string conversation_id { get; set; }
        /// <summary>
        /// 用户标识，由开发者定义规则，需保证用户标识在应用内唯一。
        /// </summary>
        public required string user { get; set; }
        /// <summary>
        /// 当前页第一条聊天记录的 ID，默认 null
        /// </summary>
        public required string? first_id { get; set; } = null;

        /// <summary>
        /// 一次请求返回多少条聊天记录，默认 20 条。
        /// </summary>
        public int limit { get; set; }
    }
    public class GetDifyHistoryChatDataListRsp
    {

    }

    #endregion
}
