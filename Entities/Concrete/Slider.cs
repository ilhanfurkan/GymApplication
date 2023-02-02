using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Slider : BaseEntity, IEntity
    {
        [Key]
        public int SliderId { get; set; }   
        public string SliderTitle { get; set; }
        public string SliderImage { get; set; }
        public string SliderDetail { get; set; }
    }
}
