namespace Entities.Helpers;

public class PagedMetadata(int totalCount, int pageSize, int currentPage, int totalPages, bool hasNext, bool hasPreviou)
{
    public int TotalCount { get; set; } = totalCount;
    public int PageSize { get; set; } = pageSize;
    public int CurrentPage { get; set; } = currentPage;
    public int TotalPages { get; set; } = totalPages;
    public bool HasNext { get; set; } = hasNext;
    public bool HasPreviou { get; set; } = hasPreviou;
}