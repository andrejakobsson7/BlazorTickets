using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared.Models
{
    public class TicketTag
    {
        [Column("ticket_id")]
        public int TicketId { get; set; }

        //Navigation property
        [JsonIgnore]
        public TicketModel? Ticket { get; set; }

        [Column("tag_id")]
        public int TagId { get; set; }

        //Navigation property
        [JsonIgnore]
        public TagModel? Tag { get; set; } // Sparas som ett heltal (int) i databasen(enumens value), går sedan att omvandla till det motsvarande namnet.
    }
}
