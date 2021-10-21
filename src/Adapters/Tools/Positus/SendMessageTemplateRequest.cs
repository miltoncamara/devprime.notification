using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DevPrime.Tools.Positus
{
    public class SendMessageTemplateRequest
    {
        public SendMessageTemplateRequest(string to, string message)
        {
            To = to;
            Type = "text";
            Text = new Text
            {
                Body = message
            };
        }

        [JsonPropertyName("to")]
        public string To { get; }

        [JsonPropertyName("type")]
        public string Type { get; }

        [JsonPropertyName("template")]
        public Template Template { get; }
        [JsonPropertyName("text")]
        public Text Text { get; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public class Text
    {
        [JsonPropertyName("body")]
        public string Body { get; set; }
    }

    public class Template
    {
        public string @namespace { get; set; }
        public Language language { get; set; }
        public string name { get; set; }
        public List<Component> components { get; set; }
    }

    public class Language
    {
        public string policy { get; set; }
        public string code { get; set; }
    }

    public class Parameter
    {
        public Parameter(string value)
        {
            type = "text";
            text = value;
        }

        public string type { get; set; }
        public string text { get; set; }
    }

    public class Component
    {
        public string type { get; set; }
        public List<Parameter> parameters { get; set; }
    }
}
