using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GACWareHousingApi.Models
{
    public class SalesOrderDetail : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string OrderCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
