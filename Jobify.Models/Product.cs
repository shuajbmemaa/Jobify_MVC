using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobify.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Pozita e Punes")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Pershkrimi { get; set; }
        [Required]
        public string Kerkesat { get; set; }

        [ForeignKey("Puna")]
        public int PunaId { get; set; }
        
        public Puna Puna { get; set; }
        
    }
}
