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
    public class MySimpleButton : SimpleButton, IStatusBarDescription
    {
        public MySimpleButton()
        {
            Appearance.ForeColor = Color.Maroon;
        }

        public string StatusBarDescription { get; set; }
    }
}
