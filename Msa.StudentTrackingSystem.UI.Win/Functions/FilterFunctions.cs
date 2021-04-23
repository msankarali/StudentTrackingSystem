using Msa.StudentTrackingSystem.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Msa.StudentTrackingSystem.UI.Win.Functions
{
    public class FilterFunctions
    {
        public static Expression<Func<T, bool>> Filter<T>(bool showActiveCards)
            where T : BaseEntityDurum
        {
            return x => x.Durum == showActiveCards;
        }

        public static Expression<Func<T, bool>> Filter<T>(long id)
            where T : BaseEntityDurum
        {
            return x => x.Id == id;
        }
    }
}
