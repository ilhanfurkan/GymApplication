using Entities.Concrete;

namespace GymGymACoreApplication.Models
{
	public class RegistrationPacketUserModel
	{
		public UserCategoryTrainer UserCategoryTrainer { get; set; }
		public IEnumerable<CategoryTrainer> CategoryTrainers { get; set; }
		public IEnumerable<User> Users { get; set; }
	}
}
