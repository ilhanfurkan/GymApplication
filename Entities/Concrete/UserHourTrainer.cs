using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserHourTrainer : IEntity  //Randevular Tablosu -- Appointments Table
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public int Hours  { get; set; }
        public bool Active { get; set; }

        //HourTrainer ve User'ın Idsini Tutacak.
        public int SeanceId { get; set; }
        public virtual HourTrainer HourTrainer { get; set; }

        public int UserId { get; set; }
        public virtual User user { get; set; }

    }
}
