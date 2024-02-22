using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
	public class ResponseModel
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("response")]
		public string? Response { get; set; }

		[Column("submitted_by")]
		public string? SubmittedBy { get; set; }

		[Column("ticket_id")]
		public int TicketId { get; set; }

		//Navigation property
		public TicketModel? Ticket { get; set; }
	}

}
