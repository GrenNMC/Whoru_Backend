using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class FeedGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Khóa ngoại
        public int GroupId { get; set; }
        public int FeedId { get; set; }

        // Connect to table 
        public Feed? Feed { get; set; }
        public Group? Group { get; set; }
    }
}
