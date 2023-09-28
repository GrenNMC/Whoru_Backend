using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class UserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? Backround { get; set; }

        // Foreign keys
        public int? UserId { get; set; }

        // Connect to tables
        public User? User { get; set; }
        public List<UserInfo>? Follower { get; set; }
        public List<UserInfo>? Following { get; set; }
        public List<Share>? Shares { get; set; }
        public List<Like>? Likes { get; set; }
        //public List<Notification>? Notifications { get; set; }
        //public List<Chat>? Chats { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
