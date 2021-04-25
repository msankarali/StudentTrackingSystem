using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.Common.Message;
using Msa.StudentTrackingSystem.Model.Entities.Base;
using Msa.StudentTrackingSystem.UI.Win.UserControls.Controls;
using System;
using System.Windows.Forms;

namespace Msa.StudentTrackingSystem.UI.Win.Functions
{
    public static class GeneralFunctions
    {
        public static long GetRowId(this GridView table)
        {
            if (table.FocusedRowHandle > -1)
                return (long)table.GetFocusedRowCellValue("Id");

            Messages.ValidRowNotSelectedMessage();
            return -1;

        }

        public static T GetRow<T>(this GridView table, bool withMessage = true)
        {
            if (table.FocusedRowHandle > -1)
                return (T)table.GetRow(table.FocusedRowHandle);

            if (withMessage)
                Messages.ValidRowNotSelectedMessage();

            return default(T);
        }

        public static VariableChangePositions GetVariableChangePosition<T>(T oldEntity, T currentEntity)
        {
            foreach (var prop in currentEntity.GetType().GetProperties())
            {
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;
                var oldValue = prop.GetValue(oldEntity) ?? string.Empty;
                var currentValue = prop.GetValue(currentEntity) ?? string.Empty;

                if (prop.PropertyType == typeof(byte[]))
                {
                    if (string.IsNullOrEmpty(oldValue.ToString()))
                        oldValue = new byte[] { 0 };
                    if (string.IsNullOrEmpty(currentEntity.ToString()))
                        currentValue = new byte[] { 0 };

                    if (((byte[])oldValue).Length != ((byte[])currentValue).Length)
                        return VariableChangePositions.Field;
                }
                else if (!currentValue.Equals(oldValue))
                {
                    return VariableChangePositions.Field;
                }
            }
            return VariableChangePositions.None;
        }

        public static void ButtonEnabledState<T>(
            BarButtonItem btnNew,
            BarButtonItem btnSave,
            BarButtonItem btnUndo,
            BarButtonItem btnDelete,
            T oldEntity, T currentEntity)
        {
            var variableChangePosition = GetVariableChangePosition<T>(oldEntity, currentEntity);
            var buttonEnabledState = variableChangePosition == VariableChangePositions.Field;

            btnSave.Enabled = buttonEnabledState;
            btnUndo.Enabled = buttonEnabledState;

            btnNew.Enabled = !buttonEnabledState;
            btnDelete.Enabled = !buttonEnabledState;
        }

        public static long GenerateId(this FormOperationType formOperationType, BaseEntity selectedEntity)
        {
            string AddZero(string value)
            {
                if (value.Length == 1)
                    return "0" + value;
                return value;
            }

            string AddZeroToTreeDigitNumbers(string value)
            {
                switch (value.Length)
                {
                    case 1:
                        return "00" + value;
                    case 2:
                        return "0" + value;
                }

                return value;
            }

            string Id()
            {
                var year = DateTime.Now.Date.Year.ToString();
                var month = AddZero(DateTime.Now.Date.Month.ToString());
                var day = AddZero(DateTime.Now.Date.Day.ToString());
                var hour = AddZero(DateTime.Now.Hour.ToString());
                var minute = AddZero(DateTime.Now.Minute.ToString());
                var second = AddZero(DateTime.Now.Second.ToString());
                var millisecond = AddZeroToTreeDigitNumbers(DateTime.Now.Millisecond.ToString());
                var random = AddZero(new Random().Next(0, 99).ToString());

                return year + month + day + hour + minute + second + millisecond + random;
            }

            return
                formOperationType == FormOperationType.EntityUpdate
                ? selectedEntity.Id
                : long.Parse(Id());
        }

        public static void ControlEnabledChange(this MyButtonEdit baseEdit, Control paramEdit)
        {
            switch (paramEdit)
            {
                case MyButtonEdit btnEdit:
                    btnEdit.Enabled = baseEdit.Id.HasValue && baseEdit.Id > 0;
                    btnEdit.Id = null;
                    btnEdit.EditValue = null;
                    break;
            }
        }


    }
}