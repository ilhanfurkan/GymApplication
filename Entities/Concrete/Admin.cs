using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Admin : IEntity
    {
        [Key]
        public int adminId { get; set; }
        [StringLength(20)]
        public string adminName { get; set; }
        [StringLength(20)]
        public string adminPassword { get; set; }
        [StringLength(50)]
        public string mail { get; set; }
        [StringLength(20)]
        public string adminType { get; set; }
        public bool Delete { get; set; }
        
    }
}
