using CSharpUtils.DifyAI;
using DifyAI.ObjectModels;


namespace CSharpUtils.DifyAI.ChatMessage
{
    public class DifyAIChatMessages : DifyAIClientBase
    {

        public DifyAIChatMessages(string baseDomain, string apiKey, string datasetApiKey) : base(baseDomain, apiKey, datasetApiKey)
        {

        }

        public async Task<ChatCompletionResponse> SendChatMsg(ChatCompletionRequest req)
        {
            var rsp = await _difyAIService.ChatMessages.ChatAsync(req);
            return rsp;
        }

        public async Task SendStreamChatMsg(ChatCompletionRequest req, Action<ChunkCompletionResponse> updateNextDataCallbcak)
        {
            await foreach (var rsp in _difyAIService.ChatMessages.ChatStreamAsync(req))
            {
                if (rsp == null)
                {
                    continue;
                }
                updateNextDataCallbcak?.Invoke(rsp);
            }
        }

        public async Task<MessageHistoryResponse> GetHistoryInfo(MessageHistoryRequest req)
        {
           var historyRsp = await _difyAIService.Messages.HistoryAsync(req);
            return historyRsp;
        }

    }
}
