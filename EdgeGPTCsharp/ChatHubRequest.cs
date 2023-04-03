using System.Data;

namespace EdgeGPTCsharp
{
    public class ChatHubRequest
    {
        private string conversation_Signature;
        private string client_Id;
        private string conversation_Id;
        private int invocation_Id;
        public string _struct;
        public ChatHubRequest(string conversation_signature, string client_id, string conversation_id, int invocation_id = 0)
        {
            conversation_Signature = conversation_signature;
            client_Id = client_id;
            conversation_Id = conversation_id;
            invocation_Id = invocation_id;
        }
        public void Update(string prompt, string conversation_style, List<Object> options)
        {
            string optionssss = $@"[""deepleo"",""enable_debug_commands"",""disable_emoji_spoken_text"",""enablemm"",""{conversation_style.ToLower()}""]";
            _struct = @$"{{""arguments"": [{{""source"": ""cib"", ""optionsSets"": [""deepleo"", ""enable_debug_commands"", ""disable_emoji_spoken_text"", ""enablemm"",""nlu_direct_response_filter"",""harmonyv3""],""allowedMessageTypes"":[""Chat"",""InternalSearchQuery""], ""isStartOfSession"": {(invocation_Id == 0).ToString().ToLower()}, ""message"": {{""author"": ""user"", ""inputMethod"": ""Keyboard"", ""text"": ""{prompt}"", ""messageType"": ""Chat""}}, ""conversationSignature"": ""{conversation_Signature}"", ""participant"": {{""id"": ""{client_Id}""}}, ""conversationId"": ""{conversation_Id}""}}], ""invocationId"": ""{invocation_Id}"", ""target"": ""chat"", ""type"": 4}}";
            this.invocation_Id += 1;
        }
    }
}