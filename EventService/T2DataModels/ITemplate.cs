using System.Collections.Generic;

namespace WebThunder.t2.DataModels
{
    public interface ITemplate
    {
        int templateID { get; set; }
        string displayName { get; set; }
        List<IField> fields { get; set; }
        int? titleField { get; set; }
        int? locationField { get; set; }
        bool? allowLocationOverrides { get; set; }
    }
}