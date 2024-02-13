
using System.Reflection;
using System.Linq.Dynamic.Core;
using System.Text;

namespace Entities.Helpers;

public class SortHelper<T> : ISortHelper<T>
{
    public IQueryable<T> ApplySort(IQueryable<T> query, string? orderByStr)
    {
        if (!query.Any())
        {
            return query;
        }

        if (string.IsNullOrWhiteSpace(orderByStr))
        {
            return query;
        }

        var orderParams = orderByStr.Trim().Split(',');
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        foreach (var orderParam in orderParams)
        {
            string trimedOrderParam = orderParam.Trim();
            if (string.IsNullOrWhiteSpace(orderParam))
            {
                continue;
            }

            string propertyFromQueryName = trimedOrderParam.Split(" ")[0];
            var objectProperty = properties.FirstOrDefault(prop => prop.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
            if (objectProperty == null)
            {
                return query;
            }
            string order = trimedOrderParam.EndsWith(" desc") ? "descending" : "ascending";
            orderQueryBuilder.Append($"{objectProperty.Name} {order}, ");
        }

        string orderString = orderQueryBuilder.ToString().TrimEnd(',', ' ');

        Console.WriteLine(orderString);

        return query.OrderBy(orderString);
    }
}