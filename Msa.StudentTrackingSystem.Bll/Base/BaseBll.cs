using Msa.Dal.Interfaces;
using Msa.StudentTrackingSystem.Bll.Interfaces;
using Msa.StudentTrackingSystem.Model.Entities.Base;
using System;
using System.Data.Entity;
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

        protected BaseBll() { }

        protected BaseBll(Control ctrl)
        {
            _ctrl = ctrl;
        }

        protected TResult BaseSingle<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {

            return _uow.Rep.Find(filter, selector);
        }

        #region Dispose
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
