using PrimeNG.TableFilter;
using PrimeNG.TableFilter.Utils;
using System.Collections.Generic;
using System.Linq;
using Watchdog.Core.BLL.Models;

namespace Watchdog.Core.BLL.Extensions
{
    public static class TableFilterExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> dataSet, FilterModel filterPayload, out int totalRecord)
        {
            filterPayload.Filters = new Dictionary<string, object>(filterPayload.Filters.Where(f => f.Key.ToLower() != "global"));

            if (filterPayload.GlobalFilter is not null)
            {
                string filterLower = filterPayload.GlobalFilter.Value.ToLower();
                var propertyNames = filterPayload.GlobalFilter.Fields;

                var properties = typeof(T).GetProperties()
                    .Where(p =>
                        p.PropertyType == typeof(string)
                        && propertyNames.Any(n => n.FirstCharToUpper() == p.Name));

                dataSet = dataSet
                    .Where(entity => properties.Any(property => property.GetValue(entity)
                                                                        .ToString()
                                                                        .ToLower()
                                                                        .Contains(filterLower)));
            }

            return dataSet.PrimengTableFilter(filterPayload, out totalRecord);
        }
    }
}
