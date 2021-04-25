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

namespace Msa.StudentTrackingSystem.UI.Win.Forms.IlceForms
{
    public partial class IlceEditForm : BaseEditForm
    {
        #region Variables
        private readonly long _ilId;
        private readonly string _ilAdi;
        #endregion

        public IlceEditForm(params object[] param)
        {
            InitializeComponent();

            _ilId = (long)param[0];
            _ilAdi = param[1].ToString();

            DataLayoutControl = myDataLayoutControl;
            Bll = new IlceBll(myDataLayoutControl);
            BaseCardType = CardType.Ilce;
            EventsLoad();
        }

        protected internal override void LoadForm()
        {
            OldEntity =
                BaseFormOperationType == FormOperationType.EntityInsert
                ? new Ilce()
                : ((IlceBll)Bll).Single(FilterFunctions.Filter<Ilce>(Id));
            BindObjectsToControls();
            Text = Text += $" - ({_ilAdi})";

            if (BaseFormOperationType != FormOperationType.EntityInsert) return;
            txtKod.Text = ((IlceBll)Bll).GenerateNewKod(x => x.IlId == _ilId);
            txtIlceAdi.Focus();
        }

        protected override void BindObjectsToControls()
        {
            var entity = (Ilce)OldEntity;
            txtKod.Text = entity.Kod;

            txtIlceAdi.Text = entity.IlceAdi;

            tglDurum.IsOn = entity.Durum;
            txtAciklama.Text = entity.Aciklama;
        }

        protected override void CreateNewerObject()
        {
            CurrentEntity = new Ilce
            {
                Id = Id,
                Kod = txtKod.Text,

                IlceAdi = txtIlceAdi.Text,
                IlId = _ilId,

                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButtonEnabledStatus();
        }

        protected override bool EntityInsert()
        {
            return ((IlceBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.IlId == _ilId);
        }

        protected override bool EntityUpdate()
        {
            return ((IlceBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.IlId == _ilId);
        }
    }
}