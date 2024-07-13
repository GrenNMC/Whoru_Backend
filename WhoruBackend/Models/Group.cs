using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string? NameGroup { get; set; }
        public string? DescriptionGroup { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<FeedGroup>? Feeds { get; set; }
        public List<MemberGroup>? Members { get; set; }
    }
}
