using AngleSharp.Io;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WFAI.Utils.Net.HttpEx
{
    internal class HttpClientEx
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<string> GetAsync<TRequest>(string url)
        {
            try
            {
                var responseString = await client.GetStringAsync(url);
                return responseString;
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError($"网络请求异常:{ex.Message}");
                //UIMessageBox.ShowError($"网络请求异常:{ex.Message}");
                return ex.Message;
            }
        }
        public static async Task<TRespone?> GetAsync<TRequest,TRespone>(string url)
        {
            try
            {
                var responseString = await client.GetStringAsync(url);
                Console.WriteLine("GetAsync:"+ responseString);
                TRespone? rsp;
                if (!string.IsNullOrEmpty(responseString))
                {
                     rsp = JsonConvert.DeserializeObject<TRespone>(responseString);
                    return rsp;
                }
                else
                {
                    throw new Exception("未解析到数据");
                }
            }
            catch (Exception ex)
            {
                //UIMessageTip.ShowError($"网络请求异常:{ex.Message}");
                UIMessageBox.ShowError($"网络请求异常:{ex.Message}");
                return default;
            }
           
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string resource, T body)
        {
            // Use appropriate serialization based on your needs:
            // .NET Core 3.1+ or .NET 5+ (using System.Net.Http.Json):
            return await client.PostAsJsonAsync(resource, body);


            // Newtonsoft.Json:
            // var json = JsonConvert.SerializeObject(body);
            // var content = new StringContent(json, Encoding.UTF8, "application/json");
            // return await _client.PostAsync(resource, content);


        }
    }
}
