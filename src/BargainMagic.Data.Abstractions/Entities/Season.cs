namespace BargainMagic.Data.Abstractions.Entities;

public class Season
{
    public long Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public string Description { get; set; }

    public Season(long id, 
                  string name,
                  DateTime createdDateTime,
                  string description)
    {
        Id = id;
        Name = name;
        CreatedDateTime = createdDateTime;
        Description = description;
    }
}
