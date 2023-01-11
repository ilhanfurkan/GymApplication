using Entities.Concrete;

namespace GymGymACoreApplication.Models
{
	public class RegistrationPacketUserModel
	{
		public UserCategoryTrainer registrationModel { get; set; }
		public IEnumerable<CategoryTrainer> packetModel { get; set; }
		public IEnumerable<User> userModel { get; set; }
	}
}
