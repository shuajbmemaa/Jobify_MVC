using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Jobify.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Emri i kategorise")]
        [MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
    }
}
