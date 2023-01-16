using Entities.Concrete;

namespace GymGymACoreApplication.Models
{
	public class PacketCategoryTrainerModel
	{
		public CategoryTrainer CategoryTrainer { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public IEnumerable<Trainer> Trainers { get; set; }
	}
}
