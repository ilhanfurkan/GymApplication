

using Entities.Concrete;

namespace GymGymACoreApplication.Models
{
    public class SeanceHourTrainerModel
    {
        public HourTrainer seanceModel { get; set; }
        public IEnumerable<Hour> hourModel { get; set; }
        public IEnumerable<Trainer> trainerModel { get; set; }
    }
}
