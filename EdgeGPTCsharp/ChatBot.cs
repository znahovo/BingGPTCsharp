using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeGPTCsharp
{
    public class ChatBot
    {
        string cookiePath = "";
        JToken cookies = "";
        ChatHub chat_hub;
        public ChatBot(string cookiePath = null, JToken cookies = null)
        {
            this.cookiePath = cookiePath;
            this.cookies = cookies;


            if (cookiePath == null)
            {
                this.chat_hub = new ChatHub(new Conversation(cookies));
            }
            this.chat_hub = new ChatHub(new Conversation(cookiePath: cookiePath));
        }


        public async Task<JToken> Ask(string prompt, string style)
        {
            return await this.chat_hub.Ask_Stream(prompt, style);
        }
    }
}
