using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class Chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Message { get; set; }
        public string? Type {  get; set; }
        public bool? IsSeen {  get; set; }
        public int? Status { get; set; } //1: Normal, 2: Pending

        //Khoa ngoai
        public int? UserSend { get; set; }
        public int? UserReceive { get; set; }

        // Connect to tables
        public UserInfo? Sender { get; set; }
        public UserInfo? Receiver { get; set; }
    }
}
