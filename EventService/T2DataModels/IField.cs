using System.Collections.Generic;
using EventService.Models;

namespace WebThunder.t2.DataModels
{
    public interface IField
    {
        int fieldID { get; set; }
        string displayName { get; set; }
        string description { get; set; }
        FieldType fieldType { get; set; }
        bool? htmlEditorEnabled { get; set; }
        bool? showDescription { get; set; }
        bool? conflictChecksEnabled { get; set; }
        bool? requiresValue { get; set; }
        string[] defaultValue { get; set; }
        List<IAsset> allowedValues { get; set; }
        bool? allowsMultipleValues { get; set; }
        FieldDisplayStyle displayStyle { get; set; }
        int? minChars { get; set; }
        int? maxChars { get; set; }
        int? minValue { get; set; }
        int? maxValue { get; set; }
    }
}