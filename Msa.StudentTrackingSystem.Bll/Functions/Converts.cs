using Msa.StudentTrackingSystem.Model.Entities.Base.Interfaces;
using System;
using System.Linq;

namespace Msa.StudentTrackingSystem.Bll.Functions
{
    public static class Converts
    {
        public static TTarget EntityConvert<TTarget>(this IBaseEntity source)
        {
            if (source == null) return default(TTarget);
            var destination = Activator.CreateInstance<TTarget>();
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = typeof(TTarget).GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var value = sourceProperty.GetValue(source);
                var destProp = destinationProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);
                if (destProp != null)
                    destProp.SetValue(destination, ReferenceEquals(value, "") ? null : value);
            }

            return destination;
        }
    }
}