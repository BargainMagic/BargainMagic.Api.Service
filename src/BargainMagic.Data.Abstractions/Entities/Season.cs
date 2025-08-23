namespace BargainMagic.Data.Abstractions.Entities;

/// <summary>
/// A defined period a set of rules is enforced utilizing a specific <see cref="CardSnapshot"/>.
/// </summary>
public class Season
{
    /// <summary>
    /// A unique identifier for the <see cref="Season"/>.
    /// </summary>
    public required long Id { get; set; }

    /// <summary>
    /// A readable identifier for the <see cref="Season"/>.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The date and time the <see cref="Season"/> was created.
    /// </summary>
    public required DateTime CreatedDateTime { get; set; }

    /// <summary>
    /// A description of the <see cref="Season"/>.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The unique identifier of the <see cref="CardSnapshot"/> being used rules enforcement during the <see cref="Season"/>.
    /// </summary>
    public long? CardSnapshotId { get; set; }

    /// <summary>
    /// The <see cref="CardSnapshot"/> being used for rules enforcement during the <see cref="Season"/>.
    /// </summary>
    public CardSnapshot? CardSnapshot { get; set; }
}
