﻿using Msa.Dal.Base;
using Msa.Dal.Interfaces;
using Msa.StudentTrackingSystem.Model.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;

namespace Msa.StudentTrackingSystem.Bll.Functions
{
    public static class GeneralFunctions
    {
        public static List<string> GetChangedFields<T>(this T oldEntity, T currentEntity)
        {
            List<string> fields = new List<string>();

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
                    {
                        fields.Add(prop.Name);
                    }
                }
                else if (!currentValue.Equals(oldValue))
                {
                    fields.Add(prop.Name);
                }
            }

            return fields;
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["StudentTrackingSystemContext"].ConnectionString;
        }

        private static TContext CreateContext<TContext>()
            where TContext : DbContext
        {
            return (TContext)Activator.CreateInstance(typeof(TContext), GetConnectionString());
        }

        public static void CreateUnitOfWork<T, TContext>(ref IUnitOfWork<T> uow)
            where T : class, IBaseEntity
            where TContext : DbContext
        {
            uow?.Dispose();
            uow = new UnitOfWork<T>(CreateContext<TContext>());
        }
    }
}