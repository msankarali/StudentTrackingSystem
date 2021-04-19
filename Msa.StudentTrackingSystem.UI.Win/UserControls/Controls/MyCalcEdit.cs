﻿using DevExpress.Utils;
using DevExpress.XtraEditors;
using Msa.StudentTrackingSystem.UI.Win.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msa.StudentTrackingSystem.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCalcEdit : CalcEdit, IStatusBarShortcut
    {
        public MyCalcEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DefaultBoolean.False;
            Properties.EditMask = "n2";
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarShortcut { get; set; } = "F4: ";
        public string StatusBarShortcutDescription { get; set; } = "Hesap Makinesi";
        public string StatusBarDescription { get; set; }
    }
}
