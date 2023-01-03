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
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=DESKTOP-BF2NAS2;Initial Catalog=GymGym-A;" +
               "Persist Security Info=False;Trusted_Connection=True;" +
               "MultipleActiveResultSets=False;Encrypt=False;" +
               "TrustServerCertificate=False;Connection Timeout=30;");
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
