using System.Diagnostics.CodeAnalysis;

namespace EventService.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum FieldType
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
        CustomAsset = 17
    }
}