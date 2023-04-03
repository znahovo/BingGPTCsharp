using Newtonsoft.Json.Linq;

using System;
using System.Net.WebSockets;

using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WatsonWebsocket;


namespace EdgeGPTCsharp
{
    public class ChatHub
    {

        public ChatHubRequest request;
        public WatsonWsClient client;
        public bool loop;
        List<string> temp = new List<string>();
        int converIndex = 0;
        private bool flag;
        private JToken response;
        public ChatHub(Conversation conversation)
        {
            request = new ChatHubRequest(
               conversation_signature: conversation._struct.conversationSignature,
               client_id: conversation._struct.clientId,
               conversation_id: conversation._struct.conversationId
                );

        }

        public async Task<JToken> Ask_Stream(string prompt, string style)
        {
            converIndex = 0;
            client = new WatsonWsClient(new Uri("wss://sydney.bing.com/sydney/ChatHub"));
            request.Update(prompt, style, null);
            if (client.Connected)
            {
                client.StopAsync().Wait();
            }
            client.MessageReceived += Client_MessageReceived;
            client.ServerDisconnected += Client_ServerDisconnected;
            client.ServerConnected += Client_ServerConnected;
            client.StartAsync().Wait();
            HandShake(client);
            await client.SendAsync(Append_Identifier(request._struct));
            return response;
        }

        private async void Client_MessageReceived(object? sender, MessageReceivedEventArgs e)
        {

            try
            {
                var a = JToken.Parse(Encoding.UTF8.GetString(e.Data).ToString().Split("\u001e")[0]);
                if (a.Value<string>("type") != null)
                {
                    if (a.Value<string>("type").ToString() == "2")
                    {
                        temp.Clear();
                        client.Dispose();
                        response = a;
                        Console.WriteLine("dispose");
                        return;
                    }
                }
                if (a["arguments"] != null)
                {
                    if (a["arguments"][0].Value<JArray>("messages") != null)
                    {
                        if (a["arguments"][0]["messages"][0]["text"].ToString().Contains("Searching the web for"))
                        {
                            Console.WriteLine(a["arguments"][0]["messages"][0]["text"].ToString());
                        }else
                        {
                            temp.Add(a["arguments"][0]["messages"][0]["text"].ToString());
                            if (temp.Count == 1)
                            {
                                Console.Write(temp[0]);
                                converIndex++;
                            }
                            else
                            {
                                var addition = ToCharList(temp[converIndex - 1].ToCharArray());
                                var addtion2 = ToCharList(temp[converIndex].ToCharArray());
                                addtion2.RemoveRange(0, addition.Count);
                                foreach (var item in addtion2)
                                {
                                    Console.Write(item);
                                }
                                converIndex++;
                            }
                        }
                      

                     
                    }
                }


            }
            catch (Exception)
            {

            }
        }

        private void Client_ServerDisconnected(object? sender, EventArgs e)
        {
            Console.WriteLine("DisConnect");
        }

        private void Client_ServerConnected(object? sender, EventArgs e)
        {
            Console.WriteLine("Connected");
        }

        public void HandShake(WatsonWsClient wss)
        {
            wss.SendAsync(Append_Identifier("{\"protocol\": \"json\", \"version\": 1}")).Wait(2000);

        }
        public string Append_Identifier(string msg)
        {
            return msg + "\u001e";
        }
        List<char> ToCharList(char[] charArray)
        {
            List<char> result = new List<char>();
            foreach (var item in charArray)
            {
                result.Add(item);
            }
            return result;
        }
        //IEnumerable<string> TestMethod(string obj)
        //{
        //    temp.Add(obj);
        //    for (int i = 0; i < temp.Count; i++)
        //    {
        //        if (i == 0)
        //        {
        //            Console.Write(temp[0].ToString());
        //        }
        //        else
        //        {
        //            var addition = ToCharList(temp[i - 1].ToCharArray());
        //            var addtion2 = ToCharList(temp[i].ToCharArray());
        //            addtion2.RemoveRange(0, addition.Count);
        //            foreach (var item in addtion2)
        //            {
        //                Console.Write(item);
        //            }
        //        }
        //    }
        //}

    }
}