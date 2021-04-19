using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Msa.StudentTrackingSystem.UI.Win.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Msa.StudentTrackingSystem.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyComboBoxEdit : ComboBoxEdit, IStatusBarShortcut
    {
        public MyComboBoxEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarShortcut { get; set; } = "F4: ";
        public string StatusBarShortcutDescription { get; set; }
        public string StatusBarDescription { get; set; }
    }
}