using System.ComponentModel.DataAnnotations;

namespace TuksConnectAPI.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EventTitle { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public decimal TicketPrice { get; set; }
    }
}
