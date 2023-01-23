using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Admin : BaseEntity, IEntity
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(20)]
        public string AdminName { get; set; }
        [StringLength(20)]
        public string AdminPassword { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        [StringLength(20)]
        public string AdminType { get; set; }
        public bool Deleted { get; set; }

    }
}
