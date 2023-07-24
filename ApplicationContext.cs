using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Registration
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;password=root;database=register", new MySqlServerVersion(new Version(8, 0, 0)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(e => e.Role).WithMany(e => e.Users).HasForeignKey(e => e.RoleId);
        }
        public static User Sravn(string current_Login, string current_Pass)
        {
            using (var context = new ApplicationContext())
            {
                return context.Users.FirstOrDefault(t => t.Login == current_Login && t.Password == current_Pass);
            };

        }
    }
}
