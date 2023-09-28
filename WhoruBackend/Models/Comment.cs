using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Message { get; set; }
        // Khóa ngoại
        public int UserId { get; set; }
        public int FeedId { get; set; }

        // Connect to table 
        public Feed? Feed { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
