using RestSharp;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html;

namespace WFAI.Utils.Net.HttpEx
{
    internal class HttpEx
    {
        public static void Init()
        {
            if (_client == null)
            {
                _client = new RestClient();
            }
        }
      

        private static RestClient _client;

        // 可以选择传入 baseUrl，或者在每个请求中指定完整的 URL
        

        public static async Task<T> GetAsync<T>(string url, object parameters = null)
        {
            var options = new RestClientOptions(url);
            if (_client==null)
            {
                _client = new RestClient();
            }
            var request = new RestRequest(url, Method.Get);

            //if (parameters != null)
            //{
            //    // 添加查询参数
            //    foreach (var property in parameters.GetType().GetProperties())
            //    {
            //       var param = new Parameter()
            //        {
            //            Name = property.Name,

            //        }
            //        request.AddParameter(param);
            //    }
            //}

            var res = await _client.GetAsync<T>(request);
            return res;
        }

        public static async Task<RestResponse<T>> PostAsync<T>(string resource, object body)
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddJsonBody(body);  // 使用 JSON 格式发送数据

            return await _client.ExecutePostAsync<T>(request);
        }


        public static async Task<RestResponse> PostAsync(string resource, object body)
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddJsonBody(body);  // 使用 JSON 格式发送数据

            return await _client.ExecutePostAsync(request);
        }



        public static async Task<RestResponse<T>> PutAsync<T>(string resource, object body)
        {
            var request = new RestRequest(resource, Method.Put);
            request.AddJsonBody(body);

            return await _client.ExecutePutAsync<T>(request);
        }

        public static async Task<RestResponse> DeleteAsync(string resource)
        {
            var request = new RestRequest(resource, Method.Delete);

            return await _client.ExecuteAsync(request);
        }


        // 添加自定义 Header
        public static void AddDefaultHeader(string name, string value)
        {
            _client.AddDefaultHeader(name, value);
        }

      

    }
}
