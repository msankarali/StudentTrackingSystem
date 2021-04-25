using Msa.StudentTrackingSystem.Bll.General;
using Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms;
using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.Model.Dtos;
using Msa.StudentTrackingSystem.UI.Win.Functions;
using Msa.StudentTrackingSystem.Model.Entities;
using System;

namespace Msa.StudentTrackingSystem.UI.Win.Forms.OkulForms
{
    public partial class OkulEditForm : BaseEditForm
    {
        public OkulEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new OkulBll(myDataLayoutControl);
            CardType = CardType.Okul;
            EventsLoad();
        }

        protected internal override void LoadForm()
        {
            OldEntity =
                FormOperationType == FormOperationType.EntityInsert
                ? new OkulS()
                : ((OkulBll)Bll).Single(FilterFunctions.Filter<Okul>(Id));
            BindObjectsToControls();

            if (FormOperationType != FormOperationType.EntityInsert) return;
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
    }
}