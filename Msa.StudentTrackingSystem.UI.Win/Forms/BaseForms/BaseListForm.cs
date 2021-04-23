using DevExpress.XtraBars;

namespace Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms
{
    public partial class BaseListForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public BaseListForm()
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
                    case BarItem button:
                        button.ItemClick += Button_ItemClick;
                        break;
                }
            }
        }


        private void ShowEditForm(long id)
        {
            var result = ;
        }

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == btnExport)
            {
                var link = (BarSubItemLink)e.Item.Links[0];
                link.Focus();
                link.OpenMenu();
                link.Item.ItemLinks[0].Focus();
            }
            else if (e.Item == btnExcelStandartDocument)
            {

            }
            else if (e.Item == btnExcelFormattedDocument)
            {

            }
            else if (e.Item == btnExcelUnformattedDocument)
            {

            }
            else if (e.Item == btnWordDocument)
            {

            }
            else if (e.Item == btnPdfDocument)
            {

            }
            else if (e.Item == btnTxtDosyasi)
            {

            }
            else if (e.Item == btnNew)
            {
                //Auth controls
                ShowEditForm();
            }
        }
    }
}