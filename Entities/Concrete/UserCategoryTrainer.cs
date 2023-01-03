using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserCategoryTrainer : IEntity //Kayıtlar Tablosu -- Registration Table
    {
        [Key]
        public int RegistrationId { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public double PaymentType { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        //User ve CategoryTrainer Tablolarının Id'sini bulunduracak
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int PacketId { get; set; }
        public virtual CategoryTrainer CategoryTrainer { get; set; }
    }
}
