using System.Runtime.Serialization;

namespace BookRate.Common.Enums
{
    public enum CoverType
    {
        [EnumMember(Value = "Paperback")]
        Paperback,
        [EnumMember(Value = "Hardcover")]
        Hardcover,
        [EnumMember(Value = "Leatherbound")]
        Leatherbound,
        [EnumMember(Value = "DustJacket")]
        DustJacket,
        [EnumMember(Value = "Flexibound")]
        Flexibound,
        [EnumMember(Value = "BoardBook")]
        BoardBook,
        [EnumMember(Value = "Other")]
        Other
    }
}
