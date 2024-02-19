
using System.Reflection;
using System.Linq.Dynamic.Core;
using System.Text;
using Entities.Models;

namespace Entities.Helpers;

public class QueryHelper<T> : IQueryHelper<T>
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
        return query.OrderBy(orderString);
    }

    public IQueryable<T> ApplyFilters(IQueryable<T> query, QueryStringParameters parameters)
    {
        var parametersProperties = parameters.GetType().GetProperties()
            .Where(p => !typeof(QueryStringParameters).GetProperties().Select(q => q.Name).Contains(p.Name));
        var objectProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var whereString = new StringBuilder();
        
        foreach (PropertyInfo param in parametersProperties)
        {
            var objProperty = objectProperties.FirstOrDefault(obj => obj.Name.Equals(param.Name, StringComparison.InvariantCultureIgnoreCase));

            if (objProperty == null)
            {
                continue;
            }

            if (param.GetValue(parameters) == null)
            {
                continue;
            }

            if (whereString.Length > 1)
            {
                whereString.Append(" and ");
            }

            if (param.PropertyType == typeof(string))
            {
                whereString.Append($"{objProperty.Name}.ToLower().Contains(\"{param.GetValue(parameters)!.ToString()!.ToLowerInvariant()}\")");
            }
            else
            {
                whereString.Append($"{objProperty.Name} = {param.GetValue(parameters)}");

            }
        }

        if (whereString.Length == 0)
        {
            return query;   
        }

        return query.Where(whereString.ToString());
    }
}