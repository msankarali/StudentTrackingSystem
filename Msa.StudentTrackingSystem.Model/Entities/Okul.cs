﻿using Msa.StudentTrackingSystem.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Msa.StudentTrackingSystem.Model.Entities
{
    public class Okul : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, MaxLength(50)]
        public string OkulAdi { get; set; }
        public long IlId { get; set; }
        public long IlceId { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public Il Il { get; set; }
        public Ilce Ilce { get; set; }
    }
}
