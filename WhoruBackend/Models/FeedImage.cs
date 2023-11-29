using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class FeedImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? ImageName {  get; set; }
        //Khóa ngoại
        public int? FeedId { get; set; }
        //Connect to table 
        public Feed? Feed { get; set; }
    }
}
