using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
	public class TagModel
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("name")]
		public string? Name { get; set; }

		//Navigation property
		public List<TicketTag> TicketTags { get; set; } = new();
	}

}
