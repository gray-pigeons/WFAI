using DifyAI.Interfaces;
using DifyAI.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

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
        public DifyAIClientBase(string baseDomain, string apiKey, string datasetApiKey)
        {
            var services = new ServiceCollection();

            var httpClientBuilder = services
                .AddDifyAIService(x =>
                {
                    x.BaseDomain = baseDomain;
                    x.DefaultApiKey = apiKey;
                    x.DatasetApiKey = "dataset-rg6t21M26kP3F4ron3QtEVQT";
                });
          
            httpClientBuilder.ConfigurePrimaryHttpMessageHandler((x) =>
            {
                //var handler = new SocketsHttpHandler();
                //handler.SslOptions.EnabledSslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13; // 设置所需的 SSL/TLS 协议

                //// 其他 SocketsHttpHandler 配置，例如：
                //// handler.PooledConnectionLifetime = TimeSpan.FromMinutes(2); // 连接池生命周期
                //// handler.SslOptions.RemoteCertificateValidationCallback = //  证书验证回调 (谨慎使用)
                //handler.SslOptions.RemoteCertificateValidationCallback += (object sender, X509Certificate? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors) =>
                //{
                //    return true;
                //};
                var httpClientHander = new HttpClientHandler();
                httpClientHander.ClientCertificateOptions= ClientCertificateOption.Automatic;
                httpClientHander.ServerCertificateCustomValidationCallback += (sender, certificate, chain, sslPolicyErrors) =>
                {
                    Console.WriteLine($"验证证书: {certificate.Subject}");
                    // 这里可以添加自定义的证书验证逻辑
                    // 例如，只允许特定的证书或内部 CA 签名的证书通过校验
                    return true; // 允许所有证书（仅用于测试）
                };
                return httpClientHander;
            });

            var app = services.BuildServiceProvider();
            _difyAIService = app.GetRequiredService<IDifyAIService>();

        }

        //private void AddDifyService(Action<DifyAIOptions> configure)
        //{
        //    return _difyAIService.AddHttpClient<IDifyAIService, DifyAIService>().ConfigureHttpClient(delegate (IServiceProvider provider, HttpClient httpClient)
        //    {
        //        DifyAIOptions value = provider.GetService<IOptions<DifyAIOptions>>().Value;
        //        UriBuilder uriBuilder = new UriBuilder(value.BaseDomain);
        //        if (!uriBuilder.Path.EndsWith("/"))
        //        {
        //            uriBuilder.Path += "/";
        //        }

        //        httpClient.BaseAddress = uriBuilder.Uri;
        //        httpClient.AddAuthorization(value.DefaultApiKey);
        //    }).AddTypedClient(delegate (HttpClient httpClient, IServiceProvider provider)
        //    {
        //        IOptions<DifyAIOptions> service = provider.GetService<IOptions<DifyAIOptions>>();
        //        return new DifyAIService(httpClient, service);
        //    });
        //}
    }
}
