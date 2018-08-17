using EventService.Data;
using Newtonsoft.Json;

namespace EventService.Models
{
    public class AllowedValue
    {
        public string key;

        [JsonIgnore] public string sortKey;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string url;

        public string value;

        public AllowedValue()
        {
        }

        public AllowedValue(string value)
        {
            sortKey = key = StormHacks.MakeKeyFromDisplayName(value);
            this.value = value;
        }

        public AllowedValue(Asset asset)
        {
            key = $"asset{asset.AssetID}";
            sortKey = asset.AssetID.ToString("D5");
            value = asset.DisplayName;
        }
    }
}