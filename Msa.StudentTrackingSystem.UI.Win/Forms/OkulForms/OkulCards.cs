﻿using Msa.StudentTrackingSystem.Bll.General;
using Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms;

namespace Msa.StudentTrackingSystem.UI.Win.Forms.OkulForms
{
    public partial class OkulCards : BaseCardsForm
    {
        public OkulCards()
        {
            InitializeComponent();

            OkulBll bll = new OkulBll();
            grid.DataSource = bll.List(null);
        }
    }
}