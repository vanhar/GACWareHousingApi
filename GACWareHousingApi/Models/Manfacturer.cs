using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GACWareHousingApi.Models
{
    public class Manfacturer : EntityBase
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string ManfacturerCode { get; set; }
        [Required]
        [MaxLength(500)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Address { get; set; }
        [Required]
        [MaxLength(25)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        public int Rating { get; set; }
    }
}
