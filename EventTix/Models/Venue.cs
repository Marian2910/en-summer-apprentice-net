namespace EventTix.Models;

public partial class Venue
{
    public int VenueId { get; set; }

    public string Location { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
