using System.Collections.Generic;
using System.Linq;
using EventService.Data;
using Newtonsoft.Json;

namespace EventService.Models
{
    public class CustomField
    {
        public CustomField()
        {
        }

        public CustomField(string displayName)
        {
            this.displayName = displayName;
        }

        [JsonIgnore]
        public string _defaultValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<AllowedValue> allowedValues { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object defaultValue
        {
            get
            {
                if (fieldType == FieldType.CustomAsset && !string.IsNullOrEmpty(_defaultValue))
                    return allowedValues.SingleOrDefault(v => v.key == _defaultValue);

                return _defaultValue;
            }
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }

        public string displayName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string displayStyle { get; set; }

        [JsonIgnore]
        public int eventTypeId { get; set; }

        [JsonIgnore]
        public string eventTypeName { get; set; }

        public FieldType fieldType { get; set; }

        public string key => StormHacks.MakeKeyFromDisplayName(displayName, "event");

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? maxChars { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? maxValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? minChars { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? minValue { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool multipleValues { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool required { get; set; }
    }
}