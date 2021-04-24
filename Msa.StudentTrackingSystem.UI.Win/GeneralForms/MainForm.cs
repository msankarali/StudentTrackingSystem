using DevExpress.XtraBars;
using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.UI.Win.Forms.OkulForms;
using Msa.StudentTrackingSystem.UI.Win.Show;

namespace Msa.StudentTrackingSystem.UI.Win.GeneralForms
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
            EventsLoad();
        }

        private void EventsLoad()
        {
            foreach (var item in ribbonControl.Items)
            {
                switch (item)
                {
                    case BarItem btn:
                        btn.ItemClick += Buttons_ItemClick;
                        break;

                    default:
                        break;
                }
            }
        }

        private void Buttons_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == btnOkulCards)
                ShowListForms<OkulListForm>.ShowListForm(CardType.Okul);

        }
    }
}