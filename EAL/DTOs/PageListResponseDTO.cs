namespace EAL.DTOs;

public class PageListResponseDTO<T> where T : class
{
    public PageListResponseDTO(int pageIndex, int pageSize, int totalRecords, List<T> records)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Records = records;
        TotalRecords = totalRecords;
    }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public List<T> Records { get; set; } = new List<T>();
}
