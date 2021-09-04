using PrimeNG.TableFilter;
using PrimeNG.TableFilter.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Watchdog.Core.BLL.Models;

namespace Watchdog.Core.BLL.Extensions
{
    public static class TableFilterExtensions
    {
        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> dataSet, FilterModel filterPayload, out int totalRecord)
        {
            filterPayload.Filters = new Dictionary<string, object>(filterPayload.Filters.Where(f => f.Key.ToLower() != "global"));

            if (filterPayload.GlobalFilter is not null && !string.IsNullOrEmpty(filterPayload.GlobalFilter.Value))
            {
                string filterLower = filterPayload.GlobalFilter.Value.Trim().ToLower();
                var propertyNames = filterPayload.GlobalFilter.Fields;

                var properties = typeof(TEntity).GetProperties()
                    .Where(p =>
                        p.PropertyType == typeof(string)
                        && propertyNames.Any(n => n.FirstCharToUpper() == p.Name));

                var parameter = Expression.Parameter(typeof(TEntity), "e"); // variable e
                var expression = properties.Select(p =>
                        {
                            var property = Expression.Property(parameter, p.Name);
                            // e.Property
                            
                            var callLower = Expression.Call(property, property.Type.GetMethod("ToLower", Array.Empty<Type>()));
                            // e.Property.ToLower()         
                           
                            var callContains = Expression.Call(
                                    callLower,
                                    property.Type.GetMethod("Contains", new[] { typeof(string) }),
                                    new[] { Expression.Constant(filterLower) });
                            // e.Property.ToLower().Contains(filterLower)
                            
                            return callContains;
                        })
                    .Aggregate<Expression>((left, right) => Expression.OrElse(left, right));
                // e.Property1.ToLower().Contains(filterLower) || e.Property2.ToLower().Contains(filterLower) || ...
                
                var lambda = Expression.Lambda<Func<TEntity, bool>>(expression, parameter);
                // e => e.Property1.ToLower().Contains(filterLower) || e.Property2.ToLower().Contains(filterLower) || ...

                dataSet = dataSet.Where(lambda);
            }
            return dataSet.PrimengTableFilter(filterPayload, out totalRecord);
        }

        public static IEnumerable<TEntity> Filter<TEntity>(this IEnumerable<TEntity> dataSet, FilterModel filterPayload, out int totalRecord)
        {
            return dataSet.AsQueryable().Filter(filterPayload, out totalRecord).AsEnumerable();
        }
    }
}
