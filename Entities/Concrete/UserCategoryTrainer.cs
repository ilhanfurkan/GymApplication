using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete 
{ 
    public class UserCategoryTrainer : BaseEntity, IEntity //Kayıtlar Tablosu -- Registration Table
    {
        [Key]
        public int RegistrationId { get; set; }
        public DateTime DateOfRegistration { get; set; } 
        public bool PaymentType { get; set; }
        public double Price { get; set; }
        public bool Deleted { get; set; }

        //User ve CategoryTrainer Tablolarının Id'sini bulunduracak
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int PacketId { get; set; }
        public virtual CategoryTrainer Packet { get; set; }
    }
}
