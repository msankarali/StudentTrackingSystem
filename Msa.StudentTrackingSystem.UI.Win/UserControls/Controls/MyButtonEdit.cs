using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Msa.StudentTrackingSystem.UI.Win.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Msa.StudentTrackingSystem.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyButtonEdit : ButtonEdit, IStatusBarShortcut
    {
        public MyButtonEdit()
        {
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarDescription { get; set; }
        public string StatusBarShortcut { get; set; } = "F4 :";
        public string StatusBarShortcutDescription { get; set; }

        #region Events

        private long? _id;

        [Browsable(false)]
        public long? Id
        {
            get => _id;
            set
            {
                var oldValue = _id;
                var newValue = value;

                if (newValue == oldValue) return;
                _id = value;

                IdChanged(this, new IdChangedEventArgs(oldValue, newValue));
            }
        }

        public event EventHandler<IdChangedEventArgs> IdChanged = delegate { };

        #endregion Events
    }

    public class IdChangedEventArgs : EventArgs
    {
        public IdChangedEventArgs(long? oldValue, long? newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        public long? OldValue { get; }
        public long? NewValue { get; }
    }
}