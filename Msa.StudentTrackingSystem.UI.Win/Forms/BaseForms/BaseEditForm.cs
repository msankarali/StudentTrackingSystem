using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Msa.StudentTrackingSystem.Bll.Interfaces;
using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.Common.Message;
using Msa.StudentTrackingSystem.Model.Entities.Base;
using Msa.StudentTrackingSystem.UI.Win.Functions;
using Msa.StudentTrackingSystem.UI.Win.UserControls.Controls;
using System;
using System.Windows.Forms;

namespace Msa.StudentTrackingSystem.UI.Win.Forms.BaseForms
{
    public partial class BaseEditForm : RibbonForm
    {
        protected internal FormOperationType BaseFormOperationType;
        protected internal long Id;
        protected internal bool RefreshRequired;
        protected MyDataLayoutControl DataLayoutControl;
        protected MyDataLayoutControl[] DataLayoutControls;
        protected IBaseBll Bll;
        protected CardType BaseCardType;
        protected BaseEntity OldEntity;
        protected BaseEntity CurrentEntity;
        protected bool IsLoaded;
        protected bool FormClosingAfterSave = true;

        public BaseEditForm()
        {
            InitializeComponent();
        }

        protected void EventsLoad()
        {
            //Button events
            foreach (BarItem button in ribbonControl.Items)
                button.ItemClick += Button_ItemClick;

            //Form events
            Load += BaseEditForm_Load;

            void ControlEvents(Control control)
            {
                control.KeyDown += Control_KeyDown;

                switch (control)
                {
                    case MyButtonEdit btnEdit:
                        btnEdit.IdChanged += Control_IdChanged;
                        btnEdit.EnabledChange += Control_EnabledChange;
                        btnEdit.ButtonClick += Control_ButtonClick;
                        btnEdit.DoubleClick += Control_DoubleClick;
                        break;

                    case BaseEdit btnEdit:
                        btnEdit.EditValueChanged += Control_EditValueChanged;
                        break;
                }
            }

            if (DataLayoutControls == null)
            {
                if (DataLayoutControl == null) return;
                foreach (Control control in DataLayoutControl.Controls)
                    ControlEvents(control);
            }
            else
                foreach (var layout in DataLayoutControls)
                    foreach (Control control in layout.Controls)
                        ControlEvents(control);
        }

        protected virtual void Control_EnabledChange(object sender, EventArgs e) { }

        private void Control_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsLoaded) return;
            CreateNewerObject();
        }

        private void Control_DoubleClick(object sender, EventArgs e)
        {
            SetSelection(sender);
        }

        private void Control_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SetSelection(sender);
        }

        private void Control_IdChanged(object sender, IdChangedEventArgs e)
        {
            if (!IsLoaded) return;
            CreateNewerObject();
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();

            if (sender is MyButtonEdit btnEdit)
                switch (e.KeyCode)
                {
                    case Keys.Delete when e.Control && e.Shift:
                        btnEdit.Id = null;
                        btnEdit.EditValue = null;
                        break;

                    case Keys.F4:
                    case Keys.Down when e.Modifiers == Keys.Alt:
                        SetSelection(btnEdit);
                        break;
                }
        }

        private void BaseEditForm_Load(object sender, EventArgs e)
        {
            IsLoaded = true;
            CreateNewerObject();
            //TODO: sablon
            //ButtonHideShow();
            Id = BaseFormOperationType.GenerateId(OldEntity);

            //TODO: update operations will be applied
        }

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == btnNew)
            {
                //Auth controls

                BaseFormOperationType = FormOperationType.EntityInsert;
                LoadForm();
            }
            else if (e.Item == btnSave)
            {
                Save(false);
            }
            else if (e.Item == btnUndo)
            {
                Undo();
            }
            else if (e.Item == btnDelete)
            {
                EntityDelete();
            }
            else if (e.Item == btnClose)
            {
                Close();
            }
        }

        protected virtual void SetSelection(object sender) { }

        private void EntityDelete()
        {
            throw new NotImplementedException();
        }

        private void Undo()
        {
            throw new NotImplementedException();
        }

        private bool Save(bool closing)
        {
            bool SaveOperation()
            {
                Cursor.Current = Cursors.WaitCursor;
                switch (BaseFormOperationType)
                {
                    case FormOperationType.EntityInsert:
                        if (EntityInsert())
                            return OperationsAfterSave();

                        break;

                    case FormOperationType.EntityUpdate:
                        if (EntityUpdate())
                            return OperationsAfterSave();

                        break;
                }

                bool OperationsAfterSave()
                {
                    OldEntity = CurrentEntity;
                    RefreshRequired = true;
                    ButtonEnabledStatus();

                    if (FormClosingAfterSave)
                        Close();
                    else
                        BaseFormOperationType =
                            BaseFormOperationType == FormOperationType.EntityInsert
                            ? FormOperationType.EntityUpdate
                            : BaseFormOperationType;

                    return true;
                }

                return false;
            }

            var result =
                closing == true
                ? Messages.ClosingMessage()
                : Messages.SaveMessage();

            switch (result)
            {
                case System.Windows.Forms.DialogResult.Yes:
                    return SaveOperation();

                case System.Windows.Forms.DialogResult.No:
                    if (closing)
                        btnSave.Enabled = false;
                    return true;

                case System.Windows.Forms.DialogResult.Cancel:
                    return true;
            }

            return false;
        }

        protected virtual bool EntityInsert()
        {
            return ((IBaseGeneralBll)Bll).Insert(CurrentEntity);
        }

        protected virtual bool EntityUpdate()
        {
            return ((IBaseGeneralBll)Bll).Update(OldEntity, CurrentEntity);
        }

        protected internal virtual void LoadForm() { }

        protected virtual void BindObjectsToControls() { }

        protected virtual void CreateNewerObject() { }

        protected internal virtual void ButtonEnabledStatus()
        {
            if (!IsLoaded) return;
            GeneralFunctions.ButtonEnabledState(btnNew, btnSave, btnUndo, btnDelete, OldEntity, CurrentEntity);
        }
    }
}