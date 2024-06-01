namespace SChainIntro_MVC.BLL.Common.PageModel;

public class PageModel<T>
{
    public int PageNumber { get; set; } // 1 - page
    public int PageSize { get; set; } // 10 item in 1 page

    public int TotalPagesCount { get; set; } // Total pages count: for example, 30 pages
    public int TotalItemsCount { get; set; } // Total items count: for example, 300 item

    public List<T> Items { get; set; } = new List<T>();


    public PageModel(List<T> items, int pageNumber, int pageSize = 10)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalItemsCount = items.Count;
        TotalPagesCount = (int)Math.Ceiling(TotalPagesCount / (double)pageSize);

        Items = items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }
}
