﻿using Msa.StudentTrackingSystem.Model.Entities;
using Msa.StudentTrackingSystem.Model.Entities.Base;

namespace Msa.StudentTrackingSystem.Model.Dtos
{
    //Attribute
    public class OkulS : Okul
    {
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
    }

    public class OkulL : BaseEntity
    {
        public string OkulAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
