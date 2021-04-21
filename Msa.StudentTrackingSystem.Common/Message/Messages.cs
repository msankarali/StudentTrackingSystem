using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Msa.StudentTrackingSystem.Common.Message
{
    public class Messages
    {
        public static void ErrorMessage(string errorMessage)
        {
            XtraMessageBox.Show(errorMessage, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
