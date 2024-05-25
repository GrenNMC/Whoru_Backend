using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class Story
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? Date {  get; set; }

        public UserInfo? User { get; set; }

    }
}
