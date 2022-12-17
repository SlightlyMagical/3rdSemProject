using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            //Booking
            modelBuilder.Entity<Booking>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            //Relations
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Client)
                .WithMany(c => c.Bookings)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Coach)
                .WithMany(c => c.Bookings)
                .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<User> UserTable { get; set; }
        public DbSet<Coach> CoachTable { get; set; }
        public DbSet<Client> ClientTable { get; set; }
        public DbSet<Booking> BookingTable { get; set; }
    }
}
