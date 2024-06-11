using System.Net;
using SChainIntro_MVC.BLL.Common.Exceptions;


namespace SChainIntro_MVC.BLL.Common.PageModel;


public class PaginationParams
{
    private const int maxPageSize = 50;
    private int pageSize;

    public int PageSize
    {
        get
        {
            return pageSize;
        }
        set
        {
            if (value < maxPageSize)
            {
                pageSize = value;
            }
            else
            {
                throw new StatusCodeException(HttpStatusCode.NotAcceptable,
                    $"Page size must be less than {maxPageSize}");
            }
        }
    }
    
    public int PageIndex { get; set; }

    public PaginationParams() {}
    public PaginationParams(int pageIndex, int pageSize)
    {
        PageSize = pageSize;
        PageIndex = pageIndex;
    }

    public int SkipCount()
    {
        return (PageIndex - 1) * PageSize;
    }
}