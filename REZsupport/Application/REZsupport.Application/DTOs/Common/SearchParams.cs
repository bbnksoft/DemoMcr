namespace REZsupport.Application.DTOs.Common;

public class SearchParams : PaginationParams
{
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public string? SortOrder { get; set; } = "asc";
}