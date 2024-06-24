using System.Runtime.Serialization;

namespace BookRate.Common.Enums
{
    public enum Roles
    {
        [EnumMember(Value = "Admin")]
        Admin,

        [EnumMember(Value = "User")]
        User,

        [EnumMember(Value = "Author")]
        Author,

        [EnumMember(Value = "Ilustrator")]
        Ilustrator,

        [EnumMember(Value = "Tranlator")]
        Tranlator
    }
}
