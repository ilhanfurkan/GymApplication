using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Menu
    {
        
            [Key]
            public int menuId { get; set; }
            [StringLength(50)]
            public string MenuName { get; set; }
            [StringLength(100)]
            public string SeoUrl { get; set; }
            [ForeignKey("parent")]
            public int? ParentId { get; set; }
            public virtual Menu Parent { get; set; }
            [InverseProperty("parent")]
            public virtual ICollection<Menu> Children { get; set; }
            public bool Deleted { get; set; }

       
    }
}
