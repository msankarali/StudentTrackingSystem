using DevExpress.XtraEditors;
using Msa.StudentTrackingSystem.Bll.General;
using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.Model.Entities;
using Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms;
using Msa.StudentTrackingSystem.UI.Win.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Msa.StudentTrackingSystem.UI.Win.Forms.IlForms
{
    public partial class IlEditForm : BaseEditForm
    {
        public IlEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new IlBll(myDataLayoutControl);
            BaseCardType = CardType.Il;
            EventsLoad();
        }

        protected internal override void LoadForm()
        {
            OldEntity =
                BaseFormOperationType == FormOperationType.EntityInsert
                ? new Il()
                : ((IlBll)Bll).Single(FilterFunctions.Filter<Il>(Id));
            BindObjectsToControls();

            if (BaseFormOperationType != FormOperationType.EntityInsert) return;
            txtKod.Text = ((IlBll)Bll).GenerateNewKod();
            txtIlAdi.Focus();
        }

        protected override void BindObjectsToControls()
        {
            var entity = (Il)OldEntity;
            txtKod.Text = entity.Kod;

            txtIlAdi.Text = entity.IlAdi;

            tglDurum.IsOn = entity.Durum;
        }

        protected override void CreateNewerObject()
        {
            CurrentEntity = new Il
            {
                Id = Id,
                Kod = txtKod.Text,

                IlAdi = txtIlAdi.Text,

                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButtonEnabledStatus();
        }
    }
}