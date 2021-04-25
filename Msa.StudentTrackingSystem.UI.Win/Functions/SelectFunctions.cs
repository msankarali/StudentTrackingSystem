using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.Model.Entities;
using Msa.StudentTrackingSystem.UI.Win.Forms.IlceForms;
using Msa.StudentTrackingSystem.UI.Win.Forms.IlForms;
using Msa.StudentTrackingSystem.UI.Win.Show;
using Msa.StudentTrackingSystem.UI.Win.UserControls.Controls;
using System;

namespace Msa.StudentTrackingSystem.UI.Win.Functions
{
    public class SelectFunctions : IDisposable
    {
        #region Variables
        private MyButtonEdit _btnEdit;
        private MyButtonEdit _prmEdit;
        private CardType _cardType;
        #endregion

        public void Select(MyButtonEdit btnEdit)
        {
            _btnEdit = btnEdit;
            SetSelection();

        }
        public void Select(MyButtonEdit btnEdit, MyButtonEdit prmEdit)
        {
            _btnEdit = btnEdit;
            _prmEdit = prmEdit;
            SetSelection();
        }

        private void SetSelection()
        {
            switch (_btnEdit.Name)
            {
                case "txtIl":
                    {
                        var entity = (Il)ShowListForms<IlListForm>.ShowDialogListForm(_cardType, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.IlAdi;
                        }
                    }
                    break;

                case "txtIlce":
                    {
                        var entity = (Ilce)ShowListForms<IlceListForm>.ShowDialogListForm(_cardType, _btnEdit.Id, _prmEdit.Id, _prmEdit.Text);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.IlceAdi;
                        }
                    }
                    break;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
