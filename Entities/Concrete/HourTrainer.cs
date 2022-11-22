using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class HourTrainer
    {
        [Key]
        public int SeanceId { get; set; }
        public int Quota { get; set; }
        public int RemainingRight { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }

        //Hour ve Trainer tablosunun Id'sini bulunduracak.
        public int HourId { get; set; }
        public Hour hour { get; set; }

        public int TrainerId { get; set; }
        public Trainer trainer { get; set; }

        //UserHourTrainer'da Id'si Olacak.
        public ICollection<UserHourTrainer> UserHourTrainers { get; set; }
    }
}
