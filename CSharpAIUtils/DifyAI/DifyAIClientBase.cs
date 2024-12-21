using DifyAI.Interfaces;
using DifyAI.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace CSharpUtils.DifyAI
{
   

    public enum DifyEventType
    {
        None = 0,
        Message,
        AgentMessage,
        AgentThought,
        MessageFile,
        MessageEnd,
        TtsMessage,
        TtsMessageEnd,
        MessageRplace,
        Error,
        Ping,
    }


    public class DifyAIClientBase
    {
        protected readonly IDifyAIService _difyAIService;
        public DifyAIClientBase(string baseDomain,string apiKey,string datasetApiKey)
        {
            var services = new ServiceCollection();

            services
               .AddDifyAIService(x =>
               {
                   x.BaseDomain = baseDomain;
                   x.DefaultApiKey = apiKey;
                   x.DatasetApiKey = "dataset-rg6t21M26kP3F4ron3QtEVQT";
               });

            var app = services.BuildServiceProvider();
            _difyAIService = app.GetRequiredService<IDifyAIService>();
        }
    }
}
