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
        public string Hours { get; set; }    //Saatler hangi saati kaç dakikalık almış gibi
        public double Time { get; set; }    //Süre anlamında kaç dakikalık bir antrenman
        public bool Deleted { get; set; }

        //HourTrainer da Id'si Olacak.
        public virtual ICollection<HourTrainer> Seances { get; set; }
    }
}
