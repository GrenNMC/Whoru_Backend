using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class UserChat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdUser1 { get; set; }
        public int IdUser2 { get; set; }
        public bool isWait { get; set; } //1: isWait, 2: location

        public UserInfo? UserInfo1 { get; set; }
        public UserInfo? UserInfo2 { get; set; }
    }
}
