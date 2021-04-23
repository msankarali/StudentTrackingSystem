using System.ComponentModel;

namespace Msa.StudentTrackingSystem.Common.Enums
{
    public enum CardType : byte
    {
        [Description("Okul Kartı")]
        Okul = 1,

        [Description("İl Kartı")]
        Il = 2,

        [Description("İlçe Kartı")]
        Ilce = 3
    }
}