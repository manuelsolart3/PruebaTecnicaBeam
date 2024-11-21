namespace ApiColegio.Domain.Abstractions;
public record Page(int PageNumber, int PageSize)
{
    public int Start()
    {
        return PageSize * (PageNumber - 1);
    }
}