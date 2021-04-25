using Msa.StudentTrackingSystem.Bll.Base;
using Msa.StudentTrackingSystem.Bll.Interfaces;
using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.Data.Contexts;
using Msa.StudentTrackingSystem.Model.Entities;
using Msa.StudentTrackingSystem.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Msa.StudentTrackingSystem.Bll.General
{
    public class IlBll : BaseBll<Il, StudentTrackingSystemContext>, IBaseGeneralBll
    {
        public IlBll() { }

        public IlBll(Control ctrl) : base(ctrl) { }

        public BaseEntity Single(Expression<Func<Il, bool>> filter)
        {
            return BaseSingle(filter, x => x);
        }

        public IEnumerable<BaseEntity> List(Expression<Func<Il, bool>> filter)
        {
            return BaseList(filter, x => x).OrderBy(x => x.Kod).ToList();
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
            return BaseDelete(entity, CardType.Il);
        }

        public string GenerateNewKod()
        {
            return BaseGenerateNewKod(CardType.Il, x => x.Kod);
        }
    }
}
