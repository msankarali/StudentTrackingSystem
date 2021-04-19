using DevExpress.XtraEditors;
using Msa.StudentTrackingSystem.UI.Win.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Msa.StudentTrackingSystem.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCheckedComboBoxEdit : CheckedComboBoxEdit, IStatusBarShortcut
    {
        public MyCheckedComboBoxEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarShortcut { get; set; } = "F4: ";
        public string StatusBarShortcutDescription { get; set; }
        public string StatusBarDescription { get; set; }
    }
}
