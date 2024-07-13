using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class MemberGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Khóa ngoại
        public int GroupId { get; set; }
        public int MemberId { get; set; }

        // Connect to table 
        public UserInfo? UserInfo { get; set; }
        public Group? Group { get; set; }
    }
}
