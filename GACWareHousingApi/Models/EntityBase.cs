using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GACWareHousingApi.Models
{
    public abstract class EntityBase
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }
        [Required]
        public virtual string CreatedBy { get; set; }
        public virtual string ModifiedBy { get; set; }
        [Required]
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime ModifiedOn { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
