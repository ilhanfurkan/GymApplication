using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Murki;database=GymGym-A;trusted_connection=true;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTrainer> CategoryTrainers { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<HourTrainer> HourTrainers { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCategoryTrainer> UserCategoryTrainers { get; set; }
        public DbSet<UserHourTrainer> UserHourTrainers { get; set; }

    }
}
