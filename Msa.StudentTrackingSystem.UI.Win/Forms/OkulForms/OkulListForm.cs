using Msa.StudentTrackingSystem.Bll.General;
using Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms;
using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.UI.Win.Show;
using Msa.StudentTrackingSystem.UI.Win.Functions;
using Msa.StudentTrackingSystem.Model.Entities;

namespace Msa.StudentTrackingSystem.UI.Win.Forms.OkulForms
{
    public partial class OkulListForm : BaseListForm
    {
        public OkulListForm()
        {
            InitializeComponent();
            Bll = new OkulBll();
        }

        protected override void FillVariables()
        {
            Table = table;
            CardType = CardType.Okul;
            FormShow = new ShowEditForm<OkulEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void RefreshList()
        {
            Table.GridControl.DataSource = ((OkulBll)Bll).List(FilterFunctions.Filter<Okul>(ShowActiveCards));
        }
    }
}