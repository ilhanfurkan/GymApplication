using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Hour : IEntity
    {
        [Key]
        public int HourId { get; set; }
        [StringLength(15)]
        public string Hours { get; set; }
        public double Time { get; set; }

        //HourTrainer da Id'si Olacak.
        public ICollection<HourTrainer> HourTrainers { get; set; }
    }
}
