
namespace Msa.StudentTrackingSystem.UI.Win.UserControls.Navigators
{
    partial class SmallNavigator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmallNavigator));
            this.navigator = new DevExpress.XtraEditors.ControlNavigator();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // navigator
            // 
            this.navigator.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.navigator.Appearance.Options.UseForeColor = true;
            this.navigator.Buttons.Append.Visible = false;
            this.navigator.Buttons.CancelEdit.Visible = false;
            this.navigator.Buttons.Edit.Visible = false;
            this.navigator.Buttons.EndEdit.Visible = false;
            this.navigator.Buttons.First.ImageIndex = 0;
            this.navigator.Buttons.ImageList = this.imageCollection;
            this.navigator.Buttons.Last.ImageIndex = 3;
            this.navigator.Buttons.Next.ImageIndex = 2;
            this.navigator.Buttons.NextPage.Visible = false;
            this.navigator.Buttons.Prev.ImageIndex = 1;
            this.navigator.Buttons.PrevPage.Visible = false;
            this.navigator.Buttons.Remove.Visible = false;
            this.navigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navigator.Location = new System.Drawing.Point(0, 0);
            this.navigator.Name = "navigator";
            this.navigator.Size = new System.Drawing.Size(475, 24);
            this.navigator.TabIndex = 0;
            this.navigator.Text = "controlNavigator1";
            this.navigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Begin;
            this.navigator.TextStringFormat = "Kartlar ( {0} / {1} )";
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertImage(global::Msa.StudentTrackingSystem.UI.Win.Properties.Resources.first_16x162, "first_16x162", typeof(global::Msa.StudentTrackingSystem.UI.Win.Properties.Resources), 0);
            this.imageCollection.Images.SetKeyName(0, "first_16x162");
            this.imageCollection.InsertImage(global::Msa.StudentTrackingSystem.UI.Win.Properties.Resources.prev_16x162, "prev_16x162", typeof(global::Msa.StudentTrackingSystem.UI.Win.Properties.Resources), 1);
            this.imageCollection.Images.SetKeyName(1, "prev_16x162");
            this.imageCollection.InsertImage(global::Msa.StudentTrackingSystem.UI.Win.Properties.Resources.next_16x162, "next_16x162", typeof(global::Msa.StudentTrackingSystem.UI.Win.Properties.Resources), 2);
            this.imageCollection.Images.SetKeyName(2, "next_16x162");
            this.imageCollection.InsertImage(global::Msa.StudentTrackingSystem.UI.Win.Properties.Resources.last_16x162, "last_16x162", typeof(global::Msa.StudentTrackingSystem.UI.Win.Properties.Resources), 3);
            this.imageCollection.Images.SetKeyName(3, "last_16x162");
            // 
            // SmallNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigator);
            this.Name = "SmallNavigator";
            this.Size = new System.Drawing.Size(475, 24);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ControlNavigator navigator;
        private DevExpress.Utils.ImageCollection imageCollection;
    }
}
