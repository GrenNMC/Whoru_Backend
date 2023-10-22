using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserName { get; set; }

        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? isDisabled { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // Foreign keys
        public int RoleId { get; set; }
        // Connect to tables
        public Role? Role { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
