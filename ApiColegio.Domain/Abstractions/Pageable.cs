namespace ApiColegio.Domain.Abstractions;
public class Pageable
{
    public IEnumerable<object> ResultList { get; set; }
    public int Count { get; set; }
}