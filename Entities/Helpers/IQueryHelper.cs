using System.Linq;
using Entities.Models;

namespace Entities.Helpers;

public interface IQueryHelper<T>
{
    IQueryable<T> ApplySort(IQueryable<T> query, string? OrderBy);
    IQueryable<T> ApplyFilters(IQueryable<T> query, QueryStringParameters parameters);
}