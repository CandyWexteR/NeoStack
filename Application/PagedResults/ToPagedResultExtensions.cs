namespace Application;

public static class ToPagedResultExtensions
{
    public static PagedResult<T> ToPagedResult<T>(this IEnumerable<T> values, PagedResultInputModel model)
    {
        var valuesToSkip = (model.PageNumber - 1) * model.PageSize;
        var skip = valuesToSkip < 0 ? 0 : valuesToSkip;
        var take = model.PageSize < 0 ? 10 : model.PageSize;
        var totalValues = values.Count();
        var items = values.Skip(skip).Take(take).ToList();
        
        return new PagedResult<T>()
        {
            Items = items,
            TotalCount = totalValues
        };
    }
}