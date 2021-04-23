using DevExpress.XtraGrid.Views.Grid;
using Msa.StudentTrackingSystem.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msa.StudentTrackingSystem.UI.Win.Functions
{
    public static class GeneralFunctions
    {
        public static long GetRowId(this GridView table)
        {
            if (table.FocusedRowHandle > -1)
                return (long)table.GetFocusedRowCellValue("Id");

            Messages.ValidRowNotSelectedMessage();
            return -1;

        }

        public static T GetRow<T>(this GridView table, bool withMessage = true)
        {
            if (table.FocusedRowHandle > -1)
                return (T)table.GetRow(table.FocusedRowHandle);

            if (withMessage)
                Messages.ValidRowNotSelectedMessage();

            return default(T);
        }
    }
}
