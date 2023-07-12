namespace Common.Constants;
public static class ModelStateConstant
{
    public const string SORTORDER_REGEX = $"^({SystemConstant.ASCENDING}|{SystemConstant.DESCENDING})$";

    public const string ASCENDING = "ascending";

    public const string DESCENDING = "descending";

    public const int DEFAULT_PAGE_SIZE = 10;

    public const string VALIDATE_SORTORDER = "Sort Order must be ascending or descending!";
}