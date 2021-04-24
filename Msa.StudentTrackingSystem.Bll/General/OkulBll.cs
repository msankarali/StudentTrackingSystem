using Msa.StudentTrackingSystem.Bll.Base;
using Msa.StudentTrackingSystem.Bll.Interfaces;
using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.Data.Contexts;
using Msa.StudentTrackingSystem.Model.Dtos;
using Msa.StudentTrackingSystem.Model.Entities;
using Msa.StudentTrackingSystem.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Msa.StudentTrackingSystem.Bll.General
{
    public class OkulBll : BaseBll<Okul, StudentTrackingSystemContext>, IBaseGeneralBll
    {
        public OkulBll()
        {
        }

        public OkulBll(Control ctrl) : base(ctrl)
        {
        }

        public BaseEntity Single(Expression<Func<Okul, bool>> filter)
        {
            return BaseSingle(filter, x => new OkulS
            {
                Id = x.Id,
                Kod = x.Kod,
                OkulAdi = x.OkulAdi,
                IlId = x.IlId,
                IlAdi = x.Il.IlAdi,
                IlceId = x.Ilce.Id,
                IlceAdi = x.Ilce.IlceAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }

        public IEnumerable<BaseEntity> List(Expression<Func<Okul, bool>> filter)
        {
            return BaseList(filter, x => new OkulL
            {
                Id = x.Id,
                Aciklama = x.Aciklama,
                IlAdi = x.Il.IlAdi,
                IlceAdi = x.Ilce.IlceAdi,
                Kod = x.Kod,
                OkulAdi = x.OkulAdi
            }).OrderBy(x => x.Kod).ToList();
        }

        public bool Insert(BaseEntity entity)
        {
            return BaseInsert(entity, x => x.Kod == entity.Kod);
        }

        public bool Update(BaseEntity oldEntity, BaseEntity currentEntity)
        {
            return BaseUpdate(oldEntity, currentEntity, x => x.Kod == currentEntity.Kod);
        }

        public bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, CardType.Okul);
        }

        public string GenerateNewKod()
        {
            throw new NotImplementedException();
        }
    }
}