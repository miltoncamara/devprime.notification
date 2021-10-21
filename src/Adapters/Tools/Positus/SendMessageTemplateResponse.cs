using System.Collections.Generic;

namespace DevPrime.Tools.Positus
{
    public class SendMessageTemplateResponse
    {
        public List<Message> messages { get; set; }
        public string message { get; set; }
    }

    public class Message
    {
        public string id { get; set; }
    }
}
