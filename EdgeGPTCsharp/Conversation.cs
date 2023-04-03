using Newtonsoft.Json.Linq;
using System;
using System.Net;
using Flurl;
using Flurl.Http;

namespace EdgeGPTCsharp
{
    public class Conversation
    {
        public dynamic _struct;
        Dictionary<string, string> uaDic = new Dictionary<string, string>();
        Dictionary<string, string> cookieDic = new Dictionary<string, string>();
        string url = "https://edgeservices.bing.com/edgesvc/turing/conversation/create";

        public Conversation(JToken cookies)
        {
            InitConve(cookies);
        }
        public Conversation(string cookiePath)
        {
            InitConve(JToken.Parse(File.ReadAllTextAsync(cookiePath).Result));
        }

        async void InitConve(JToken cookies)
        {

            foreach (var item in cookies)
            {
                cookieDic.Add(item["name"]!.ToString(), item["value"]!.ToString());
            }
            _struct = url
                .WithHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36")
        .WithHeaders(GlobalVar.HEADERS_INIT_CONVER)
        .WithCookies(cookieDic)
        .GetJsonAsync().Result;
        }
    }

}
