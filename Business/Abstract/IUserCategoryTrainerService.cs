using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserCategoryTrainerService
    {
        void UserCategoryTrainerAdd(UserCategoryTrainer userCategoryTrainer);
        void UserCategoryTrainerRemove(UserCategoryTrainer userCategoryTrainer);
        void UserCategoryTrainerUpdate(UserCategoryTrainer userCategoryTrainer);
        List<UserCategoryTrainer> UserCategoryTrainerList();
        UserCategoryTrainer UserCategoryTrainerGetById(int id);


        // packet Id bir foreign keydir. bu Manager tarafında Listing değilde ListingBy ile de olabilir
        // aklıma takıldığı için not alıyorum. Sonrasında öğrenip düzelteceğim.
        UserCategoryTrainer UserCategoryTrainerGetByPacketId(int packetId); 
    }
}
