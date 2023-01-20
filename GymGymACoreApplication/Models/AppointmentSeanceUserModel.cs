using Entities.Concrete;
using System.Collections;

namespace GymGymACoreApplication.Models
{
    public class AppointmentSeanceUserModel
    {
        public UserHourTrainer UserHourTrainer { get; set; }

        public IEnumerable<HourTrainer> HourTrainers { get; set; }  

        public IEnumerable<User> Users { get; set; }
    }
}
