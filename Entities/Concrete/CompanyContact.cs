using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CompanyContact:BaseEntity,IEntity
    {
        [Key]
        public int CompanyContactId { get; set; }
        [StringLength(150)]
        public string CompanyContactDetail { get; set; }
        [StringLength(50)]
        public string CompanyContactIcon { get; set; }
      

    }
}
