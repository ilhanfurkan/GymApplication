using Entities.Concrete;
using System.Collections;

namespace GymGymACoreApplication.Models
{
    public class AppointmentSeanceUserModel
    {
        public UserHourTrainer appointmentModel { get; set; }

        public IEnumerable<HourTrainer> seanceModel { get; set; }  

        public IEnumerable<User> userModel { get; set; }
    }
}
