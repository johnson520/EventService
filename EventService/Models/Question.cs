using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable NotAccessedField.Global

namespace EventService.Models
{
    public class Question
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ControlType controlType;

        public string key;
        public string label;
        public QOption[] options;
        public bool required;
        public object value;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int order;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string type;

        public Question()
        {
        }

        public Question(string label)
        {
            this.label = label;

            var k = Regex.Replace(label, "[^a-zA-Z]+", string.Empty);
            key = k.Substring(0, 1).ToLowerInvariant() + k.Substring(1);
        }

    }

    public class QOption
    {
        public string key;
        public string value;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string url;

        public QOption()
        {
        }

        public QOption(string keyValue)
        {
            key = Regex.Replace(keyValue.ToLowerInvariant(), "[^a-zA-Z]+", string.Empty);
            value = keyValue;
        }
    }

    public enum ControlType
    {
        multiselect,
        textbox,
        singleselect,
        imagepicker,
        checkbox
    }

}