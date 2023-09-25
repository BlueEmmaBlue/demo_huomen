using System;
using System.Windows.Forms;
using System.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;

namespace demo_huomen
{
    public class CookieHandler
    {
        public CookieContainer Cookies { get; private set; } = new CookieContainer();

        public HttpClient CreateClient()
        {
            var handler = new HttpClientHandler
            {
                CookieContainer = Cookies
            };
            return new HttpClient(handler);
        }
    }
}
