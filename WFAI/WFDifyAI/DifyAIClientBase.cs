using DifyAI.Interfaces;
using DifyAI.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http;
using WFAI.Utils.Tools.IniEx;

namespace WFAI.WFDifyAI
{

    public class IniDifyChatConfigData : IniConfigData
    {
        public required string UserParams { get; set; }
        public required string UserValue { get; set; }
        public required string APIKeyParameter { get; set; }

        public required string APIKeyValue { get; set; }
    }

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


    internal class DifyAIClientBase
    {
        protected readonly IDifyAIService _difyAIService;
        public IniDifyChatConfigData difyChatConfigData;
        public DifyAIClientBase()
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
            var (isOk, res) = IniEx.GetDifyIniConfigData(difyChatConfigData);
            if (isOk)
            {
                difyChatConfigData = res;
            }
            else
            {
                throw new NullReferenceException("未读取到配置数据");
            }


            var services = new ServiceCollection();

            //services
            //    .AddDifyAIService(x =>
            //    {
            //        x.BaseDomain = "http://localhost/v1";
            //        x.DefaultApiKey = "app-i8zgSq0L0Pk6ixmvbJCHFGcU";
            //        x.DatasetApiKey = "dataset-rg6t21M26kP3F4ron3QtEVQT";
            //    });

            services
               .AddDifyAIService(x =>
               {
                   x.BaseDomain = difyChatConfigData.KeyVal;
                   x.DefaultApiKey = difyChatConfigData.APIKeyValue;
                   x.DatasetApiKey = "dataset-rg6t21M26kP3F4ron3QtEVQT";
               });

            var app = services.BuildServiceProvider();
            _difyAIService = app.GetRequiredService<IDifyAIService>();
        }


    }
}
