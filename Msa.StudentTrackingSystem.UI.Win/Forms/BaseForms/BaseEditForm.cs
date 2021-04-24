using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
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
        protected internal FormOperationType FormOperationType;
        protected internal long Id;
        protected internal bool RefreshRequired;
        protected MyDataLayoutControl DataLayoutControl;
        protected IBaseBll Bll;
        protected CardType CardType;
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
            Load += BaseEditForm_Load; ;
        }

        private void BaseEditForm_Load(object sender, EventArgs e)
        {
            IsLoaded = true;
            CreateNewerObject();
            //TODO: sablon
            //ButtonHideShow();
            Id = FormOperationType.GenerateId(OldEntity);

            //TODO: update operations will be applied
        }

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == btnNew)
            {
                //Auth controls

                FormOperationType = FormOperationType.EntityInsert;
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
                switch (FormOperationType)
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
                        FormOperationType =
                            FormOperationType == FormOperationType.EntityInsert
                            ? FormOperationType.EntityUpdate
                            : FormOperationType;

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