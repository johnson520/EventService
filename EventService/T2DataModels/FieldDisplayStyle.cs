using System.Diagnostics.CodeAnalysis;

namespace EventService.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum FieldDisplayStyle
    {
        Inline,
        DropDown,
        MultiTag,
        AutoComplete
    }
}