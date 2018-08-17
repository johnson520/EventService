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
        public string _allowedValues { get; set; }

        [JsonIgnore]
        public string _assetDisplayNames { get; set; }

        [JsonIgnore]
        public string _defaultValue { get; set; }

        [JsonIgnore]
        public short _fieldType { get; set; }

        [JsonIgnore]
        public string _multiple { get; set; }

        [JsonIgnore]
        public string _required { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<AllowedValue> allowedValues => _allowedValues != null
            ? JsonConvert.DeserializeObject<List<string>>(_allowedValues).Select(s => new AllowedValue(s)).ToList()
            : (_assetDisplayNames != null ? JsonConvert.DeserializeObject<List<AllowedValue>>(_assetDisplayNames) : null);

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

        public FieldType fieldType => (FieldType) _fieldType;

        public string key => StormHacks.MakeKeyFromDisplayName(displayName);

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? maxChars { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? maxValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? minChars { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? minValue { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool multipleValues => bool.TryParse(_multiple, out var b) && b;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool required => bool.TryParse(_required, out var b) && b;
    }
}