using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
	public class TicketModel
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("title")]
		public string? Title { get; set; }

		[Column("description")]
		public string? Description { get; set; }

		[Column("submitted_by")]
		public string? SubmittedBy { get; set; }

		[Column("is_resolved")]
		public bool IsResolved { get; set; }

		//Navigation properties
		public List<TicketTag> TicketTags { get; set; } = new();
		public List<ResponseModel> Responses { get; set; } = new();
	}

}
