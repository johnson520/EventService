
// ReSharper disable UnusedMember.Global
namespace EventService.Models
{
    public class AssetModel
    {
        public int assetID { get; set; }
        public int capacity { get; set; }
        public string capacityLabel { get; set; }
        public AssetCustomField[] customFields { get; set; }
        public string displayName { get; set; }
        public ImageObject image { get; set; }
        public string parentDisplayName { get; set; }
    }

    public class AssetCustomField
    {
        public string label { get; set; }
        public FieldType type { get; set; }
        public object value { get; set; }
    }

    public class ImageObject
    {
        public ImageSize size { get; set; }
        public string url { get; set; }
    }

    public class ImageSize
    {
        public int height { get; set; }
        public int width { get; set; }
    }

    public class AssetsResponse
    {
        public AssetModel[] assets { get; set; }
        public int itemNo { get; set; }
        public int totalItems { get; set; }
    }
}
