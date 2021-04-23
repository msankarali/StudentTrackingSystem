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

        public static DialogResult YesChoseYesNo(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult NoChoseYesNo(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult DeleteMessage(string cardName)
        {
            return NoChoseYesNo($"Seçtiğiniz {cardName} silinecektir. Onaylıyor musunuz?", "Silme onayı");
        }
    }
}
