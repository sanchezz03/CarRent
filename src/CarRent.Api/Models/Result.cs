namespace CarRent.Api.Models;

public class Result<T>
{
    public T? Data { get; set; }
    public string? Error { get; set; }
}
