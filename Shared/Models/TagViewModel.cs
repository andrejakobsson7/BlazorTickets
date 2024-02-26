namespace Shared.Models
{
    public class TagViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<TicketViewModel> Tickets { get; set; } = new();
    }
}
