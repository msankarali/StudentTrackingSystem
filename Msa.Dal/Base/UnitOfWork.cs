using Msa.Dal.Interfaces;
using Msa.StudentTrackingSystem.Common.Message;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace Msa.Dal.Base
{
    public class UnitOfWork<T> : IUnitOfWork<T>
        where T : class
    {
        #region Variables

        private readonly DbContext _context;

        #endregion Variables

        public UnitOfWork(DbContext context)
        {
            if (context == null) return;
            _context = context;
        }

        public IRepository<T> Rep => new Repository<T>(_context);

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var sqlEx = (SqlException)ex.InnerException?.InnerException;
                if (sqlEx == null)
                {
                    Messages.ErrorMessage(ex.Message);
                    return false;
                }

                switch (sqlEx.Number)
                {
                    case 208:
                        Messages.ErrorMessage("İşlem yapmak istediğiniz tablo Veritabanında bulunamadı.");
                        break;

                    case 547:
                        Messages.ErrorMessage("Seçilen kartın işlem görmüş hareketli var. Kart silinemez.");
                        break;

                    case 2601:
                    case 2627:
                        Messages.ErrorMessage("Girmiş olduğunuz Id daha önce kullanılmıştır.");
                        break;

                    case 4060:
                        Messages.ErrorMessage("İşlem yapmak istediğiniz Veritabanı Sunucuda bulunamadı.");
                        break;

                    case 18456:
                        Messages.ErrorMessage("Sunucuya bağlanılmak istenilen kullanıcı adı veya parola hatalıdır.");
                        break;

                    default:
                        Messages.ErrorMessage(sqlEx.Message);
                        break;
                }

                return false;
            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.Message);
                return false;
            }

            return true;
        }

        #region Dispose

        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                    _context.Dispose();

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion Dispose
    }
}