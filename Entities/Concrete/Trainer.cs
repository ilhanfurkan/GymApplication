﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Trainer : BaseEntity, IEntity
    {
        [Key]
        public int TrainerId { get; set; }
        [StringLength(50)]
        public string TrainerLogin { get; set; }
        [StringLength(50)]
        public string TrainerPassword { get; set; }
        [StringLength(50)]
        public string TrainerFirstName { get; set; }
        [StringLength(50)]
        public string TrainerLastName { get; set; }
        [StringLength(11)]
        public string TrainerNationalId { get; set; }
        [StringLength(11)]
        public string TrainerPhoneNo { get; set; }
        [StringLength(50)]
        public string TrainerMail { get; set; }
        public bool TrainerGender { get; set; }
        public DateTime TrainerDateOfBirth { get; set; }
        public string TrainerImgUrl { get; set; }
        public bool Deleted { get; set; }


        //HourTariner ve CategoryTrainer da Id'si Olacak

        public virtual ICollection<HourTrainer> Seances { get; set; }

        public virtual ICollection<CategoryTrainer> Packets { get; set; }
    }
}
