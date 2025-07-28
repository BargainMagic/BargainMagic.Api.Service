namespace BargainMagic.Api.Abstractions.Endpoints.Season;

public record SeasonDto
{
    /// <summary>
    /// A readable identifier for the season.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The date and time the season was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    public SeasonDto(string name,
                     DateTime createdDateTime)
    {
        Name = name;
        CreatedDate = createdDateTime;
    }
}
