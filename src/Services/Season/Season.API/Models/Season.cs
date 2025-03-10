namespace Season.API.Models;

public class Season
{
    public Guid Id { get; set; }
    public int Year { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime Created_DateTime { get; set; } = default!;
    public string Created_User { get; set; } = default!;
    public DateTime Modified_DateTime { get; set; } = default!;
    public string Modified_User { get; set; } = default!;
}
