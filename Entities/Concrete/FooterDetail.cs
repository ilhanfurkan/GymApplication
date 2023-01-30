using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class FooterDetail : BaseEntity,IEntity
    {
        [Key]
        public int FooterId { get; set; }
        [StringLength(60)]
        public string? LogoUrl { get; set; }
        [StringLength(100)]
        public string? FbUrl { get; set; }
        [StringLength(100)]
        public string? IgUrl { get; set; }
        [StringLength(100)]
        public string? TwtUrl { get; set; }
        [StringLength(100)]
        public string? YtUrl { get; set; }
        [StringLength(100)]
        public string? EmUrl { get; set; }
        [StringLength(100)]
        public string TipsTitle { get; set; }
        [StringLength(100)]
        public string TipsDetail { get; set; }
    }
}
