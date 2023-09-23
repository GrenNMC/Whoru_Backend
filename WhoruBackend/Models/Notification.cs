using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime? Date { get; set; }                        
        //Khoa ngoai
        public int? UserSend { get; set; }
        public int? UserReceive { get; set; }

        // Connect to tables
        public User? Sender { get; set; }
        public User? Receive { get; set; }
    }
}

