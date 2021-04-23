using Msa.Dal.Interfaces;
using Msa.StudentTrackingSystem.Bll.Functions;
using Msa.StudentTrackingSystem.Bll.Interfaces;
using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.Common.Functions;
using Msa.StudentTrackingSystem.Common.Message;
using Msa.StudentTrackingSystem.Model.Entities.Base;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Msa.StudentTrackingSystem.Bll.Base
{
    public class BaseBll<T, TContext> : IBaseBll
        where T : BaseEntity
        where TContext : DbContext
    {
        private readonly Control _ctrl;
        private IUnitOfWork<T> _uow;

        protected BaseBll()
        {
        }

        protected BaseBll(Control ctrl)
        {
            _ctrl = ctrl;
        }

        protected TResult BaseSingle<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            return _uow.Rep.Find(filter, selector);
        }

        protected IQueryable<TResult> BaseList<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            return _uow.Rep.Select(filter, selector);
        }

        protected bool BaseInsert(BaseEntity entity, Expression<Func<T, bool>> filter)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            //Validation
            _uow.Rep.Insert(entity.EntityConvert<T>());
            return _uow.Save();
        }

        protected bool BaseUpdate(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<T, bool>> filter)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            //Validation
            var changedFields = oldEntity.GetChangedFields(currentEntity);
            if (changedFields.Count == 0) return true;

            _uow.Rep.Update(currentEntity.EntityConvert<T>(), changedFields);
            return _uow.Save();
        }

        protected bool BaseDelete(BaseEntity entity, CardType cardType, bool mesajVer = true)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            if (mesajVer)
                if (Messages.DeleteMessage(cardType.ToName()) != DialogResult.Yes) return false;

            _uow.Rep.Delete(entity.EntityConvert<T>());
            return _uow.Save();
        }

        #region Dispose

        public void Dispose()
        {
            _ctrl?.Dispose();
            _uow?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion Dispose
    }
}