
namespace Msa.StudentTrackingSystem.UI.Win.Forms.IlceForms
{
    partial class IlceListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grid = new Msa.StudentTrackingSystem.UI.Win.UserControls.Grids.MyGridControl();
            this.table = new Msa.StudentTrackingSystem.UI.Win.UserControls.Grids.MyGridView();
            this.colId = new Msa.StudentTrackingSystem.UI.Win.UserControls.Grids.MyGridColumn();
            this.colKod = new Msa.StudentTrackingSystem.UI.Win.UserControls.Grids.MyGridColumn();
            this.colIlceAdi = new Msa.StudentTrackingSystem.UI.Win.UserControls.Grids.MyGridColumn();
            this.colAciklama = new Msa.StudentTrackingSystem.UI.Win.UserControls.Grids.MyGridColumn();
            this.longNavigator = new Msa.StudentTrackingSystem.UI.Win.UserControls.Navigators.LongNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            // 
            // 
            // 
            this.ribbonControl.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl.SearchEditItem.EditWidth = 150;
            this.ribbonControl.SearchEditItem.Id = -5000;
            this.ribbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.Size = new System.Drawing.Size(818, 109);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 109);
            this.grid.MainView = this.table;
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(818, 388);
            this.grid.TabIndex = 2;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.table});
            // 
            // table
            // 
            this.table.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.table.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.table.Appearance.FooterPanel.Options.UseFont = true;
            this.table.Appearance.FooterPanel.Options.UseForeColor = true;
            this.table.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.table.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.table.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.table.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.table.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.table.Appearance.ViewCaption.Options.UseForeColor = true;
            this.table.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colKod,
            this.colIlceAdi,
            this.colAciklama});
            this.table.GridControl = this.grid;
            this.table.Name = "table";
            this.table.OptionsMenu.EnableColumnMenu = false;
            this.table.OptionsMenu.EnableFooterMenu = false;
            this.table.OptionsMenu.EnableGroupPanelMenu = false;
            this.table.OptionsPrint.AutoWidth = false;
            this.table.OptionsPrint.PrintFooter = false;
            this.table.OptionsPrint.PrintGroupFooter = false;
            this.table.OptionsView.ColumnAutoWidth = false;
            this.table.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.table.OptionsView.RowAutoHeight = true;
            this.table.OptionsView.ShowAutoFilterRow = true;
            this.table.OptionsView.ShowGroupPanel = false;
            this.table.OptionsView.ShowViewCaption = true;
            this.table.StatusBarDescription = null;
            this.table.StatusBarShortcut = null;
            this.table.StatusBarShortcutDescription = null;
            this.table.ViewCaption = "İlçe Kartları";
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            this.colId.StatusBarDescription = null;
            this.colId.StatusBarShortcut = null;
            this.colId.StatusBarShortcutDescription = null;
            // 
            // colKod
            // 
            this.colKod.AppearanceCell.Options.UseTextOptions = true;
            this.colKod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKod.Caption = "Kod";
            this.colKod.FieldName = "Kod";
            this.colKod.Name = "colKod";
            this.colKod.OptionsColumn.AllowEdit = false;
            this.colKod.StatusBarDescription = null;
            this.colKod.StatusBarShortcut = null;
            this.colKod.StatusBarShortcutDescription = null;
            this.colKod.Visible = true;
            this.colKod.VisibleIndex = 0;
            this.colKod.Width = 91;
            // 
            // colIlceAdi
            // 
            this.colIlceAdi.Caption = "İlçe Adı";
            this.colIlceAdi.FieldName = "IlceAdi";
            this.colIlceAdi.Name = "colIlceAdi";
            this.colIlceAdi.OptionsColumn.AllowEdit = false;
            this.colIlceAdi.StatusBarDescription = null;
            this.colIlceAdi.StatusBarShortcut = null;
            this.colIlceAdi.StatusBarShortcutDescription = null;
            this.colIlceAdi.Visible = true;
            this.colIlceAdi.VisibleIndex = 1;
            this.colIlceAdi.Width = 127;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.StatusBarDescription = null;
            this.colAciklama.StatusBarShortcut = null;
            this.colAciklama.StatusBarShortcutDescription = null;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 2;
            this.colAciklama.Width = 311;
            // 
            // longNavigator
            // 
            this.longNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.longNavigator.Location = new System.Drawing.Point(0, 497);
            this.longNavigator.Name = "longNavigator";
            this.longNavigator.Size = new System.Drawing.Size(818, 24);
            this.longNavigator.TabIndex = 3;
            // 
            // IlceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 545);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.longNavigator);
            this.IconOptions.ShowIcon = false;
            this.Name = "IlceListForm";
            this.Text = "İlçe Kartları";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.longNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Grids.MyGridControl grid;
        private UserControls.Grids.MyGridView table;
        private UserControls.Grids.MyGridColumn colId;
        private UserControls.Grids.MyGridColumn colKod;
        private UserControls.Navigators.LongNavigator longNavigator;
        private UserControls.Grids.MyGridColumn colIlceAdi;
        private UserControls.Grids.MyGridColumn colAciklama;
    }
}