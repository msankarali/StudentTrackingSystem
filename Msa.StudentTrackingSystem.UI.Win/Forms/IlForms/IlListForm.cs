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

namespace Msa.StudentTrackingSystem.UI.Win.Forms.IlForms
{
    public partial class IlListForm : BaseListForm
    {
        public IlListForm()
        {
            InitializeComponent();
            Bll = new IlBll();
        }

        protected override void FillVariables()
        {
            Table = table;
            BaseCardType = CardType.Il;
            FormShow = new ShowEditForms<IlEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void RefreshList()
        {
            Table.GridControl.DataSource = ((IlBll)Bll).List(FilterFunctions.Filter<Il>(ShowActiveCards));
        }
    }
}