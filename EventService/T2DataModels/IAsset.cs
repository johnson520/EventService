using System.Collections.Generic;

namespace WebThunder.t2.DataModels
{
    public interface IAsset
    {
        int assetID { get; set; }
        string displayName { get; set; }
        List<IFieldValue> fieldValues { get; set; }
    }
}