using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserHourTrainer : BaseEntity, IEntity  //Randevular Tablosu -- Appointments Table
    {
        [Key]
        public int AppointmentId { get; set; }     //Appointment = Randevu
        public DateTime Date { get; set; }    //Randevu Tarihi
        public int Hours  { get; set; }     //Randevu Saati
        public bool ActivePassive { get; set; }
        public bool Deleted { get; set; }

        //HourTrainer ve User'ın Idsini Tutacak.
        public int SeanceId { get; set; }
        public virtual HourTrainer Seance { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
