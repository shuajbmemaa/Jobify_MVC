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
    public class Puna
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Pozita e Punes")]
        public string Emri_Pozites {  get; set; }

        [Required]
        [MaxLength(100)]
        public string Pershkrimi { get; set; }
        [Required]
        public string Kerkesat { get; set; }
        [Required]
        public string Lokacioni { get; set; }

        public string ImageUrl { get; set; }


        

    }
}
