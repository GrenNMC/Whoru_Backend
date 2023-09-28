using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]

        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }
        [Required]
        public DateTime? UpdatedDate { get; set; }

        // Foreign keys
        public int RoleId { get; set; }
        // Connect to tables
        public UserInfo? UserInfo { get; set; }
    }
}
