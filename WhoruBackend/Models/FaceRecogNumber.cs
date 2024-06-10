using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhoruBackend.Models
{
    public class FaceRecogNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId {  get; set; }
        public double Embedding {  get; set; }

        public UserInfo? UserInfo { get; set; }
    }
}
