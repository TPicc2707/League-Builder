namespace League.API.Models;
public class League
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Sport { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public DateTime Created_DateTime { get; set; } = default!;
    public string Created_User { get; set; } = default!;
    public DateTime Modified_DateTime { get; set; } = default!;
    public string Modified_User { get; set;} = default!;    
}
