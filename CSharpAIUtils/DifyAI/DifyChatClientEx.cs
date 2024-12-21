//using CSharpUtils.DifyAI.ChatMessage;
//using Newtonsoft.Json;
//using System;
//using System.Net.Http.Headers;
//using System.Net.Http.Json;

//namespace CSharpUtils.DifyAI
//{
//    public class DifyChatClientEx
//    {

//        private static readonly HttpClient _client = new HttpClient();

//        public static IniDifyChatConfigData difyChatConfigData;

//        public static void Init()
//        {

//        }

//        static DifyChatClientEx()
//        {
//            difyChatConfigData = new IniDifyChatConfigData()
//            {
//                Section = IniConfigConst.DifyServerSection,
//                KeyParameter = IniConfigConst.DifyServerAddr,
//                KeyVal = string.Empty,
//                APIKeyParameter = IniConfigConst.DifyQwenServerApiKey,
//                APIKeyValue = string.Empty,
//                UserParams = IniConfigConst.DifyUser,
//                UserValue = string.Empty,
//            };
//            //var (isOk, res) = IniEx.GetDifyIniConfigData(difyChatConfigData);
//            //if (isOk)
//            //{
//            //    difyChatConfigData = res;
//            //}
//            //else
//            //{
//            //    IniEx.SetDifyIniConfigData(iniDifyChatConfigData);
//            //}
//        }

//        public static async Task<TResponse?> SendChatMessageAsync<TRequest, TResponse>(TRequest message)
//        {
//            return await SendChatMessageAsync<TRequest, TResponse>(difyChatConfigData.KeyVal, difyChatConfigData.APIKeyValue, message);
//        }

//        public static async Task<TResponse?> SendStreamChatMessageAsync<TRequest, TResponse>(string url, string apiKey, TRequest message)
//        {
//            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
//            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//            try
//            {
//                var response = await _client.PostAsJsonAsync(url, message);
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

//        public static async Task<TResponse?> SendChatMessageAsync<TRequest, TResponse>(string url, string apiKey, TRequest message)
//        {
//            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
//            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//            try
//            {
//                var response = await _client.PostAsJsonAsync(url, message);
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

//        public static async Task<HttpResponseMessage?> SendChatMessageAsync<TRequest>(string url,string apiKey, TRequest message)
//        {
//            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
//            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//            return await _client.PostAsJsonAsync(url, message);
//        }


//        public static async Task<RspDifyChatMessage?> HandleStreamingResponse(HttpResponseMessage response)
//        {
//            try
//            {
//                if (response.IsSuccessStatusCode)
//                {
//                    using var stream = await response.Content.ReadAsStreamAsync();
//                    using var reader = new StreamReader(stream);
//                    string line = await reader.ReadToEndAsync();
//                    //UIMessageBox.Show("应答：" + line);
//                    if (line.StartsWith("data: "))
//                    {
//                        string json = line.Substring("data: ".Length);

//                        RspDifyChatMessage? message = JsonConvert.DeserializeObject<RspDifyChatMessage>(json);
//                        // Process each message part as it arrives
//                        Console.WriteLine($"Event: {message.Event}, Answer: {message.answer}");

//                        if (message.Event == "message_end")
//                        {
//                            // Handle metadata and files in the final message
//                            Console.WriteLine($"Total tokens used: {message.metadata.usage.total_tokens}");

//                        }

//                        return message;
//                    }
//                }
//                return null;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error parsing JSON: {ex.Message} ");
//                //UIMessageBox.ShowError($"响应失败:{response.IsSuccessStatusCode},Message:{ex.Message}");
//                return default;
//            }
//        }

//    }
//}
