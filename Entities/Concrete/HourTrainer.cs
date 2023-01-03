using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class HourTrainer : IEntity // Seanslar Tablosu -- Seances Table
    {
        [Key]
        public int SeanceId { get; set; }
        public int Quota { get; set; }
        public int RemainingRight { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }


        //Hour ve Trainer tablosunun Id'sini bulunduracak.
        public int HourId { get; set; }
        public virtual Hour hour { get; set; }

        public int TrainerId { get; set; }
        public virtual Trainer trainer { get; set; }

        //UserHourTrainer'da Id'si Olacak.
        public virtual ICollection<UserHourTrainer> UserHourTrainers { get; set; }
    }
}
