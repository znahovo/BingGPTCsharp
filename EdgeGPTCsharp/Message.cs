using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeGPTCsharp
{
    public class Arguments
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("optionsSets")]
        public List<string> OptionsSets { get; set; }

        [JsonProperty("isStartOfSession")]
        public bool IsStartOfSession { get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }

        [JsonProperty("conversationSignature")]
        public string ConversationSignature { get; set; }

        [JsonProperty("participant")]
        public Participant Participant { get; set; }

        [JsonProperty("conversationId")]
        public string ConversationId { get; set; }
    }

    public class Message
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("inputMethod")]
        public string InputMethod { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("messageType")]
        public string MessageType { get; set; }
    }

    public class Participant
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class RootObject
    {
        [JsonProperty("arguments")]
        public List<Arguments> Arguments { get; set; }

        [JsonProperty("invocationId")]
        public string InvocationId { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
    }

}
