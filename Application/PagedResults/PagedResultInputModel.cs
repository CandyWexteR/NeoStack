namespace Application;

public class PagedResultInputModel
{
    //TODO: Можно добавить фильры, сортировку и направление сортировки
    public int PageSize { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
}