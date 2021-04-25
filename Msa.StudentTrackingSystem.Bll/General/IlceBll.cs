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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Msa.StudentTrackingSystem.Bll.General
{
    public class IlceBll : BaseBll<Ilce, StudentTrackingSystemContext>
    {
        public IlceBll() { }

        public IlceBll(Control ctrl) : base(ctrl) { }

        public BaseEntity Single(Expression<Func<Ilce, bool>> filter)
        {
            return BaseSingle(filter, x => x);
        }

        public IEnumerable<BaseEntity> List(Expression<Func<Ilce, bool>> filter)
        {
            return BaseList(filter, x => x).OrderBy(x => x.Kod).ToList();
        }

        public bool Insert(BaseEntity entity, Expression<Func<Ilce, bool>> filter)
        {
            return BaseInsert(entity, filter);
        }

        public bool Update(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<Ilce, bool>> filter)
        {
            return BaseUpdate(oldEntity, currentEntity, filter);
        }

        public bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, CardType.Ilce);
        }

        public string GenerateNewKod(Expression<Func<Ilce, bool>> filter)
        {
            return BaseGenerateNewKod(CardType.Ilce, x => x.Kod, filter);
        }
    }
}
