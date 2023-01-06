using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        public string UserLogin { get; set; }
        [StringLength(50)]
        public string UserPassword { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public int RemainingRight { get; set; }   //Kalan Hak = Remaining Right
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(11)]
        public string NationalId { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        [StringLength(11)]
        public string PhoneNo { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        public bool Deleted { get; set; }


        // UserHourTrainer ve UserCategoryTrainer da Id'si olacak.

        public virtual ICollection<UserHourTrainer> Appointments{ get; set; }
        public virtual ICollection<UserCategoryTrainer> Registrations { get; set; }
    }
}
