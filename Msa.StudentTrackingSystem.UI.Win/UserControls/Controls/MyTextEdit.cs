﻿using DevExpress.XtraEditors;
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
    public class MyTextEdit : TextEdit, IStatusBarDescription
    {
        public MyTextEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.MaxLength = 50;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarDescription { get; set; }
    }
}
