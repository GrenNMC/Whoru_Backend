using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class Follow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // Foreign keys
        public int IdFollower { get; set; }
        public int IdFollowing { get; set; }

        //Connect to tables
        public UserInfo? Follower { get; set; }
        public UserInfo? Following { get; set; }
    }
}
