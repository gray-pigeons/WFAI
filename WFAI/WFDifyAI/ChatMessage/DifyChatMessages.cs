using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using Masuit.Tools;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAI.WFDifyAI.ChatMessage
{
    internal class DifyChatMessages : DifyAIClientBase
    {
        public async Task<ChatCompletionResponse> SendChatMsg(ChatCompletionRequest req)
        {
            var rsp = await _difyAIService.ChatMessages.ChatAsync(req);
            return rsp;
        }
        public async Task SendStreamChatMsg(ChatCompletionRequest req,Action<ChunkCompletionResponse> updateNextDataCallbcak)
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

    }
}
