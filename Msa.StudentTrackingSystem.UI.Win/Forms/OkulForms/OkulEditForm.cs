using Msa.StudentTrackingSystem.Bll.General;
using Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms;
using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.Model.Dtos;
using Msa.StudentTrackingSystem.UI.Win.Functions;
using Msa.StudentTrackingSystem.Model.Entities;
using System;
using Msa.StudentTrackingSystem.UI.Win.UserControls.Controls;
using DevExpress.XtraEditors;

namespace Msa.StudentTrackingSystem.UI.Win.Forms.OkulForms
{
    public partial class OkulEditForm : BaseEditForm
    {
        public OkulEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new OkulBll(myDataLayoutControl);
            BaseCardType = CardType.Okul;
            EventsLoad();
        }

        protected internal override void LoadForm()
        {
            OldEntity =
                BaseFormOperationType == FormOperationType.EntityInsert
                ? new OkulS()
                : ((OkulBll)Bll).Single(FilterFunctions.Filter<Okul>(Id));
            BindObjectsToControls();

            if (BaseFormOperationType != FormOperationType.EntityInsert) return;
            txtKod.Text = ((OkulBll)Bll).GenerateNewKod();
            txtOkulAdi.Focus();
        }

        protected override void BindObjectsToControls()
        {
            var entity = (OkulS)OldEntity;
            txtKod.Text = entity.Kod;
            txtOkulAdi.Text = entity.OkulAdi;

            txtIl.Id = entity.IlId;
            txtIl.Text = entity.IlAdi;

            txtIlce.Id = entity.IlceId;
            txtIlce.Text = entity.IlceAdi;

            tglDurum.IsOn = entity.Durum;
            txtAciklama.Text = entity.Aciklama;
        }

        protected override void CreateNewerObject()
        {
            CurrentEntity = new Okul
            {
                Id = Id,
                Kod = txtKod.Text,

                OkulAdi = txtOkulAdi.Text,

                IlId = Convert.ToInt64(txtIl.Id),
                IlceId = Convert.ToInt64(txtIlce.Id),

                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButtonEnabledStatus();
        }

        protected override void SetSelection(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var select = new SelectFunctions())
            {
                if (sender == txtIl)
                {
                    select.Select(txtIl);
                }
                else if (sender == txtIlce)
                {
                    select.Select(txtIlce, txtIl);
                }
            }
        }
    }
}