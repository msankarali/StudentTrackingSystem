using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace Msa.StudentTrackingSystem.Common.Message
{
    public class Messages
    {
        public static void ErrorMessage(string errorMessage)
        {
            XtraMessageBox.Show(errorMessage, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void WarningMessage(string warningMessage)
        {
            XtraMessageBox.Show(warningMessage, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult YesChoseYesNo(string message, string header)
        {
            return XtraMessageBox.Show(message, header, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult NoChoseYesNo(string message, string header)
        {
            return XtraMessageBox.Show(message, header, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static DialogResult DeleteMessage(string cardName)
        {
            return NoChoseYesNo($"Seçtiğiniz {cardName} silinecektir. Onaylıyor musunuz?", "Silme onayı");
        }

        public static void ValidRowNotSelectedMessage()
        {
            WarningMessage("Lütfen bir kart seçiniz.");
        }

        public static DialogResult YesChoseYesNoCancel(string message, string header)
        {
            return XtraMessageBox.Show(message, header, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ClosingMessage()
        {
            return YesChoseYesNoCancel("Yapılan değişiklikler kayıt edilsin mi?", "Çıkış onayı");
        }

        public static DialogResult SaveMessage()
        {
            return YesChoseYesNo("Yapılan değişiklikler kayıt edilsin mi?", "Kayıt onayı");
        }
    }
}