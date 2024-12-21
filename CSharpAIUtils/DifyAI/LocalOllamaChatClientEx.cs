//using Newtonsoft.Json;
//using System.Net.Http.Headers;
//using System.Net.Http.Json;

//namespace CSharpUtils.DifyAI
//{
//    public class LocalOllamaChatConfigData : IniConfigData
//    {
//        public required string ModelParams { get; set; }
//        public required string ModelValue { get; set; }
//        public required string UserParameter { get; set; }

//        public required string UserValue { get; set; }
//    }

//    public class LocalOllamaChatClientEx
//    {
//        private static readonly HttpClient _client = new HttpClient();
//        public static LocalOllamaChatConfigData localOllamaChatConfigData;

//        private const string APIGenerate = "/api/generate";
//        private const string APIChat = "/api/chat";
//        //public static async Task<TResponse?> SendChatMessageAsync<TRequest, TResponse>(TRequest message)
//        //{
//        //    return await SendChatMessageAsync<TRequest, TResponse>(localOllamaChatConfigData.KeyVal, localOllamaChatConfigData.APIKeyValue, message);
//        //}

//        public static void Init()
//        {

//        }

//        static LocalOllamaChatClientEx()
//        {
//            localOllamaChatConfigData = new LocalOllamaChatConfigData()
//            {
//                Section = IniConfigConst.OllamaServerSection,
//                KeyParameter = IniConfigConst.OllamaBaseServerAddr,
//                KeyVal = string.Empty,
//                ModelParams = IniConfigConst.OllamaModel,
//                ModelValue = string.Empty,
//                UserParameter = IniConfigConst.OllamaUser,
//                UserValue = string.Empty,

//            };
//            //var (isOk, res) = IniEx.GetDifyIniConfigData(localOllamaChatConfigData);
//            //if (isOk)
//            //{
//            //    localOllamaChatConfigData = res;
//            //    //_client.BaseAddress = new Uri("http://localhost:11434");
//            //    string baseURL = localOllamaChatConfigData.KeyVal;
//            //    //if (baseURL.Contains("localhost") || baseURL.Contains("127.0.0.1"))
//            //    //{
//            //    //    baseURL = "http://{}";
//            //    //}
//            //    _client.BaseAddress = new Uri(baseURL);

//            //}
//        }


//        public static async Task<TResponse?> SendChatMessageAsync<TRequest, TResponse>(TRequest message)
//        {
//            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
//            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//            try
//            {
//                //string url = $"{localOllamaChatConfigData.KeyVal}{APIChat}";
//                var response = await _client.PostAsJsonAsync(APIGenerate, message);
//                if (response.IsSuccessStatusCode)
//                {
//                    Console.WriteLine("Chat message sent successfully.");
//                    // Process the response as needed (e.g., read the response stream)
//                    var responseString = await response.Content.ReadAsStringAsync();
//                    //UIMessageBox.Show("应答：" + responseString);
//                    if (!string.IsNullOrEmpty(responseString))
//                    {
//                        TResponse? rsp = JsonConvert.DeserializeObject<TResponse>(responseString);
//                        return rsp;
//                    }
//                    else
//                    {
//                        throw new Exception("未解析到数据");
//                    }
//                }
//                else
//                {
//                    Console.WriteLine($"Failed to send chat message. Status code: {response.StatusCode}");
//                    Console.WriteLine($"Response: {await response.Content.ReadAsStringAsync()}"); // Log the erroqr response
//                    throw new Exception($"Failed to send chat message. Status code: {response.StatusCode}");
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error sending chat message: {ex.Message}");
//                //UIMessageTip.ShowError($"网络请求异常:{ex.Message}");
//                //UIMessageBox.ShowError($"网络请求异常:{ex.Message}");
//                return default;
//            }
//        }
//    }
//}
