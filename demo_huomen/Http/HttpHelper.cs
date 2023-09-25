using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace demo_huomen
{
    public class HttpHelper
    {
        private readonly HttpClient httpClient;

        public HttpHelper()
        {
            httpClient = new HttpClient();
        }

        // 发送HTTP GET请求并返回响应字符串
        public async Task<string> GetAsync(string url)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); // 确保响应状态码为成功

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        // 发送HTTP POST请求并返回响应字符串
        public async Task<string> PostAsync(string url, string content)
        {
            HttpContent httpContent = new StringContent(content);
            httpContent.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);
            response.EnsureSuccessStatusCode(); // 确保响应状态码为成功

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
