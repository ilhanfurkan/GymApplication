

using Entities.Concrete;

namespace GymGymACoreApplication.Models
{
    public class SeanceHourTrainerModel
    {
        public HourTrainer HourTrainer { get; set; }
        public IEnumerable<Hour> Hours { get; set; }
        public IEnumerable<Trainer> Trainers { get; set; }
    }
}
