namespace Shared.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? SubmittedBy { get; set; }

        public bool IsResolved { get; set; }

        public List<TagViewModel> Tags { get; set; } = new();
    }
}
