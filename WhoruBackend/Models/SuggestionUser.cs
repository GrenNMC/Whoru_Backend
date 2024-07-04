using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class SuggestionUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SuggestUser { get; set; }
        public int Type {  get; set; } //1: feed, 2: location

        public UserInfo? UserInfo { get; set; }
        public UserInfo? SuggestUserInfo { get; set; }
    }
}
