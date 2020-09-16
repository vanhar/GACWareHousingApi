using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GACWareHousingApi.Models
{
    public class Product : EntityBase
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string ProductCode { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(50)]
        public string UOM { get; set; }
        [Required]
        [MaxLength(250)]
        public string Dimensions { get; set; }
        public float Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string ManfacturerCode { get; set; }
    }
}
