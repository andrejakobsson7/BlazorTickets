using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
	public class TicketTag
	{
		[Column("ticket_id")]
		public int TicketId { get; set; }

		//Navigation property
		public TicketModel? Ticket { get; set; }

		[Column("tag_id")]
		public int TagId { get; set; }

		//Navigation property
		public TagModel? Tag { get; set; } // Sparas som ett heltal (int) i databasen(enumens value), går sedan att omvandla till det motsvarande namnet.
	}
}
