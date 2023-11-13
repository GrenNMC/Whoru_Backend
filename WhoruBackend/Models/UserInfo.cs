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
        // Contact 
        // Description
        // Working at
        // Sturdy at
        // Story
        // 

        // Foreign keys
        public int? UserId { get; set; }

        // Connect to tables
        public User? User { get; set; }
        public List<Feed>? Feeds { get; set; }
        public List<Follow>? Follower { get; set; }
        public List<Follow>? Following { get; set; }
        public List<Share>? Shares { get; set; }
        public List<Like>? Likes { get; set; }
        public List<Notification>? SendNotifications { get; set; }
        public List<Notification>? ReceiveNotifications { get; set; }
        public List<Chat>? SendChats { get; set; }
        public List<Chat>? ReceiveChats { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
