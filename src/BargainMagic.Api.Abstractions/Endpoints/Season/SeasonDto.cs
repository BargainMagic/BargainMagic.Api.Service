namespace BargainMagic.Api.Abstractions.Endpoints.Season;

public record SeasonDto
{
    /// <summary>
    /// A unique identifier for the season.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// A readable identifier for the season.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The date and time the season was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    public SeasonDto(long id,
                     string name,
                     DateTime createdDateTime)
    {
        Id = id;
        Name = name;
        CreatedDate = createdDateTime;
    }
}
