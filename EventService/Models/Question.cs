using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable NotAccessedField.Global

namespace EventService.Models
{
    public class Question
    {
        public QOption[] allowedValues;
        public object defaultValue;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string description;

        public string displayName;

        [JsonConverter(typeof(StringEnumConverter))]
        public FieldType fieldType;

        public string key;
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? maxChars;
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal? maxValue;
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? minChars;
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal? minValue;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int order;

        public bool required;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string type;

        public Question()
        {
        }

        public Question(string displayName)
        {
            this.displayName = displayName;

            var k = Regex.Replace(displayName, "[^a-zA-Z]+", string.Empty);
            key = k.Substring(0, 1).ToLowerInvariant() + k.Substring(1);
        }
    }

    public class QOption
    {
        public string key;

        [JsonIgnore] public string sortKey;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string url;

        public string value;

        public QOption()
        {
        }

        public QOption(string keyValue)
        {
            key = Regex.Replace(keyValue.ToLowerInvariant(), "[^a-zA-Z]+", string.Empty);
            value = keyValue;
        }
    }

    public enum FieldType
    {
        multiselect,
        textbox,
        singleselect,
        imagepicker,
        checkbox
    }

    public enum FT
    {
        SingleLine = 0,
        MultiLine = 1,
        Number = 2,
        Boolean = 3,
        Currency = 4,
        Enumeration = 5,
        Url = 6,
        DateTime = 7,
        TimeSpan = 8,
        RichLocation = 9,
        Period = 10,
        Email = 11,
        PhoneUS = 12,
        PhoneInt = 13,
        PhoneUS10NoExt = 14,
        PhoneUS10OptExt = 15,
        Image = 16,
    }
}