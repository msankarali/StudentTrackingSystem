using Msa.Dal.Interfaces;
using Msa.StudentTrackingSystem.Common.Enums;
using Msa.StudentTrackingSystem.Common.Functions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Msa.Dal.Base
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        #region Variables

        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        #endregion Variables

        public Repository(DbContext context)
        {
            if (context == null) return;
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Insert(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                _context.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(T entity, IEnumerable<string> fields)
        {
            _dbSet.Attach(entity);
            var entry = _context.Entry(entity);
            foreach (var field in fields)
                entry.Property(field).IsModified = true;
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                _context.Entry(entity).State = EntityState.Deleted;
        }

        public TResult Find<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            return filter == null
                ? _dbSet.Select(selector).FirstOrDefault()
                : _dbSet.Where(filter).Select(selector).FirstOrDefault();
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            return filter == null
                ? _dbSet.Select(selector)
                : _dbSet.Where(filter).Select(selector);
        }

        public string GenerateNewKod(CardType cardType, Expression<Func<T, string>> filter, Expression<Func<T, bool>> where = null)
        {
            string Kod()
            {
                string kod = null;
                var kodArray = cardType.ToName().Split(' ');

                for (int i = 0; i < kodArray.Length - 1; i++)
                {
                    kod += kodArray[i];

                    if (i + 1 < kodArray.Length - 1)
                    {
                        kod += " ";
                    }
                }

                return kod += "-0001";
            }

            string GenerateNewKod(string kod)
            {
                var numberedValues = "";
                foreach (var character in kod)
                {
                    if (char.IsDigit(character))
                        numberedValues += character;
                    else
                        numberedValues = "";
                }

                var numberAfterChange = (int.Parse(numberedValues) + 1).ToString();
                var difference = kod.Length - numberAfterChange.Length; //0049 -> 50
                if (difference < 0)
                    difference = 0;

                var newValue = kod.Substring(0, difference);
                newValue += numberAfterChange; //Sample-0050 √

                return newValue;
            }

            var maxKod =
                where == null
                ? _dbSet.Max(filter)
                : _dbSet.Where(where).Max(filter);
            return
                maxKod == null
                ? Kod()
                : GenerateNewKod(maxKod);
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