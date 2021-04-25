using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms;
using Msa.StudentTrackingSystem.UI.Win.Show.Interfaces;
using System;

namespace Msa.StudentTrackingSystem.UI.Win.Show
{
    public class ShowEditForms<TForm> : IBaseFormShow
        where TForm : BaseEditForm
    {
        public long ShowDialogEditForm(CardType cardType, long id)
        {
            //TODO: Auth control

            using (var form = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                form.BaseFormOperationType =
                    id > 0
                    ? FormOperationType.EntityUpdate
                    : FormOperationType.EntityInsert;
                form.Id = id;
                form.LoadForm();
                form.ShowDialog();
                return form.RefreshRequired ? form.Id : 0;
            }
        }

        public long ShowDialogEditForm(CardType cardType, long id, params object[] param)
        {
            //TODO: Auth control

            using (var form = (TForm)Activator.CreateInstance(typeof(TForm), param))
            {
                form.BaseFormOperationType =
                    id > 0
                    ? FormOperationType.EntityUpdate
                    : FormOperationType.EntityInsert;
                form.Id = id;
                form.LoadForm();
                form.ShowDialog();
                return form.RefreshRequired ? form.Id : 0;
            }
        }
    }
}