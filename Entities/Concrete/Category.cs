using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        public bool Deleted { get; set; }

        //CategoryTrainer da Id'si olacak.
        public virtual ICollection<CategoryTrainer> Packets { get; set; }
    }
}
