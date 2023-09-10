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

        // Foreign keys
        public int? UserId { get; set; }

        // Connect to tables
        public User? User { get; set; }
    }
}
