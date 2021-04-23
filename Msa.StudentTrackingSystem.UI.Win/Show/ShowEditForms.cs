using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms;
using Msa.StudentTrackingSystem.UI.Win.Show.Interfaces;
using System;

namespace Msa.StudentTrackingSystem.UI.Win.Show
{
    public class ShowEditForm<TForm> : IBaseFormShow
        where TForm : BaseEditForm
    {
        public long ShowDialogEditForm(CardType cardType, long id) //, params object[] param)
        {
            //TODO: Auth control

            using (var form = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                form.formOperationType =
                    id > 0
                    ? FormOperationType.EntityUpdate
                    : FormOperationType.EntityInsert;
                form.id = id;
                form.Load();
                form.ShowDialog();
                return form.refreshRequired ? form.id : 0;
            }
        }
    }
}