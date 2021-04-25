using DevExpress.XtraEditors;
using Msa.StudentTrackingSystem.Bll.General;
using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.Model.Entities;
using Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms;
using Msa.StudentTrackingSystem.UI.Win.Functions;
using Msa.StudentTrackingSystem.UI.Win.Show;
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
    public partial class IlceListForm : BaseListForm
    {
        #region Variables
        private readonly long _ilId;
        private readonly string _ilAdi;
        #endregion

        public IlceListForm(params object[] param)
        {
            InitializeComponent();
            Bll = new IlceBll();

            _ilId = (long)param[0];
            _ilAdi = param[1].ToString();
        }

        protected override void FillVariables()
        {
            Table = table;
            BaseCardType = CardType.Ilce;
            Navigator = longNavigator.Navigator;
        }

        protected override void RefreshList()
        {
            Table.GridControl.DataSource = ((IlceBll)Bll).List(x => x.Durum == ShowActiveCards && x.IlId == _ilId);
        }

        protected override void ShowEditForm(long id)
        {
            var result = new ShowEditForms<IlceEditForm>().ShowDialogEditForm(CardType.Ilce, id, _ilId, _ilAdi);
            // operations
        }
    }
}