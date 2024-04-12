namespace SecureMicroservices.Client.Models;

public class Movie
{
    public Guid Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Genre { get; set; } = default!;
    public string Rating { get; set; } = default!;
    public DateTime ReleaseDate { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public string Owner { get; set; } = default!;
}
