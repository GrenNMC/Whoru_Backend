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
        public string? AvtName {  get; set; }
        public string? Backround { get; set; }
        public string? BackroundName { get; set; }
        public string? Description { get; set; }
        public string? WorkingAt { get; set; }
        public string? StudyAt {  get; set; }

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
        public List<Story>? Stories { get; set; }
        public Location? Location { get; set; }
        
        public List<FaceRecogNumber>? Embeddings { get; set; }
        public List<SuggestionUser>? SuggestionUsers {  get; set; }
        public List<SuggestionUser>? isSuggestionUsers { get; set; }
    }
}
