namespace BargainMagic.Data.Abstractions.Entities;

public class Season
{
    public long Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public Season(long id, 
                  string name,
                  DateTime createdDateTime)
    {
        Id = id;
        Name = name; 
        CreatedDateTime = createdDateTime;
    }
}
