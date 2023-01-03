﻿using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CategoryTrainer : IEntity // Paketler Tablosu -- Packets Table
    {
        [Key]
        public int PacketId { get; set; }
        [StringLength(50)]
        public string PacketName { get; set; }
        [StringLength(150)]
        public string PacketDetail { get; set; }
        [StringLength(10)]
        public string PacketPrice { get; set; }
        public int Right { get; set; }
        public bool Active { get; set; }

        //Category ve Trainer tablolarının Id'sini Tutacak
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
        //UserCategoryTrainer tablosunda Id'si Olacakk.

        public virtual ICollection<UserCategoryTrainer> UserCategoryTrainers { get; set; }

    }
}
