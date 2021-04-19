﻿using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using Msa.StudentTrackingSystem.UI.Win.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Msa.StudentTrackingSystem.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyDateEdit : DateEdit, IStatusBarShortcut
    {
        public MyDateEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DefaultBoolean.False;
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarShortcut { get; set; } = "F4: ";
        public string StatusBarShortcutDescription { get; set; } = "Tarih seç";
        public string StatusBarDescription { get; set; }
    }
}