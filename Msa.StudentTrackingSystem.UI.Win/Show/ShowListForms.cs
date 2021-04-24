using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms;
using System;
using System.Windows.Forms;

namespace Msa.StudentTrackingSystem.UI.Win.Show
{
    public class ShowListForms<TForm>
        where TForm : BaseListForm
    {
        public static void ShowListForm(CardType cardType)
        {
            //TODO: Auth controls

            var form = (TForm)Activator.CreateInstance(typeof(TForm));
            form.MdiParent = Form.ActiveForm;

            form.LoadForm();
            form.Show();
        }
    }
}