using Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace EAL.DTOs;

public class BaseListRequestDTO
{
    public int PageIndex { get; set; } = 1;

    public int PageSize { get; set; } = SystemConstant.DEFAULT_PAGE_SIZE;

    [RegularExpression(ModelStateConstant.SORTORDER_REGEX, ErrorMessage = ModelStateConstant.VALIDATE_SORTORDER)]
    public string SortOrder { get; set; } = string.Empty;

    public string SortColumn { get; set; } = SystemConstant.DEFAULT_SORTCOLUMN;

    public BaseListRequestDTO()
    {
        PageIndex = PageIndex < 1 ? 1 : PageIndex;
        PageSize = PageSize < 1 ? SystemConstant.DEFAULT_PAGE_SIZE : PageSize;
    }
}
