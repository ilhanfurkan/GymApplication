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
             optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server=402-02 ; database=GymGym-A ;Encrypt=False; User ID=sa;Password=1234");

            //optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server=DESKTOP-5F5SU1M\\SQLEXPRESS ;Initial Catalog=GymGym-A;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

            //optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=Murki;Initial Catalog=GymGym-A;" +
            //   "Persist Security Info=False;Trusted_Connection=True;" +
            //   "MultipleActiveResultSets=False;Encrypt=False;" +
            //   "TrustServerCertificate=False;Connection Timeout=30;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTrainer> Packets { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<HourTrainer> Seances { get; set; }  // Seanslar demek
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCategoryTrainer> Registrations { get; set; } // Kayıtlar demek
        public DbSet<UserHourTrainer> Appointments { get; set; }  // Randevular demek
        public DbSet<Admin> Admins { get; set; }  // Admin 
        public DbSet<Menu> Menus { get; set; } //menu
        public DbSet<ChoseUs> ChoseUs { get; set; } //menu
    }
}
