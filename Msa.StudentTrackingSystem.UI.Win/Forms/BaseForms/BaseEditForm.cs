﻿using DevExpress.XtraBars.Ribbon;
using Msa.StudentTrackingSystem.Common.Enums;

namespace Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms
{
    public partial class BaseEditForm : RibbonForm
    {
        protected internal FormOperationType formOperationType;
        protected internal long id;
        protected internal bool refreshRequired;
        public BaseEditForm()
        {
            InitializeComponent();
        }

        protected internal void Load()
        {

        }
    }
}