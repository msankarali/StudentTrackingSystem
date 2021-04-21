using Msa.StudentTrackingSystem.Model.Entities.Base;

namespace Msa.StudentTrackingSystem.Model.Entities
{
    public class Okul : BaseEntityDurum
    {
        public string OkulAdi { get; set; }
        public long IlId { get; set; }
        public long IlceId { get; set; }
        public string Aciklama { get; set; }

        public Il Il { get; set; }
        public Ilce Ilce { get; set; }
    }
}
