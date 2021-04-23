using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.UI.Win.Functions;
using Msa.StudentTrackingSystem.UI.Win.Show.Interfaces;
using System.Windows.Forms;

namespace Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms
{
    public partial class BaseListForm : RibbonForm
    {
        protected IBaseFormShow FormShow;
        protected CardType CardType;
        protected internal GridView Table;
        protected bool ShowActiveCards = true;

        public BaseListForm()
        {
            InitializeComponent();
            EventsLoad();
        }

        private void EventsLoad()
        {
            //Button events
            foreach (BarItem button in ribbonControl.Items)
                button.ItemClick += Button_ItemClick;

            //Table events

            //Form events
        }


        private void ShowEditForm(long id)
        {
            var result = FormShow.ShowDialogEditForm(CardType, id);
        }

        private void EntityDelete()
        {
            throw new System.NotImplementedException();
        }

        private void SelectEntity()
        {
            throw new System.NotImplementedException();
        }

        private void RefreshList()
        {
            throw new System.NotImplementedException();
        }

        private void ApplyFilter()
        {
            throw new System.NotImplementedException();
        }

        private void Print()
        {
            throw new System.NotImplementedException();
        }

        private void SetFormCaption()
        {
            throw new System.NotImplementedException();
        }

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

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
                //TODO: Auth controls

                ShowEditForm(-1);
            }
            else if (e.Item == btnEdit)
            {
                ShowEditForm(Table.GetRowId());
            }
            else if (e.Item == btnDelete)
            {
                //TODO: Auth controls

                EntityDelete();
            }
            else if (e.Item == btnSelect)
            {
                SelectEntity();
            }
            else if (e.Item == btnRefresh)
            {
                RefreshList();
            }
            else if (e.Item == btnFilter)
            {
                ApplyFilter();
            }
            else if (e.Item == btnColumns)
            {
                if (Table.CustomizationForm == null)
                    Table.ShowCustomization();
                else
                    Table.HideCustomization();
            }
            else if (e.Item == btnPrint)
            {
                Print();
            }
            else if (e.Item == btnClose)
            {
                Close();
            }
            else if (e.Item == btnActivePassiveCards)
            {
                ShowActiveCards = !ShowActiveCards;
                SetFormCaption();
            }

            Cursor.Current = DefaultCursor;
        }

    }
}