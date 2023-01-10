using Entities.Concrete;

namespace GymGymACoreApplication.Models
{
	public class PacketCategoryTrainerModel
	{
		public CategoryTrainer packetModel { get; set; }
		public IEnumerable<Category> categoryModel { get; set; }
		public IEnumerable<Trainer> trainerModel { get; set; }
	}
}
