using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class Feed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Status { get; set; }
        public DateTime? Date { get; set; }
        public string? State {  get; set; }
        // Khóa ngoại
        public int? UserId { get; set; }
        public int? UserInfoId { get; set; }
        //Connect to tables
        public List<FeedImage>? Images { get; set;}
        public List<Share>? Shares { get; set; }
        public List<Like>? Likes { get; set; }
        public List<Comment>? Comments { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
