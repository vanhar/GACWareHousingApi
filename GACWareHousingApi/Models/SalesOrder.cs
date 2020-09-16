using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GACWareHousingApi.Models
{
    public class SalesOrder : EntityBase
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string OrderCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerCode { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

        [NotMapped]
        public IEnumerable<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
