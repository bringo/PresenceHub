using Microsoft.EntityFrameworkCore;
using PresenceHub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresenceHub.Infrastructure.DB_Context
{
   public class HubDBcontext:DbContext
    {

        public HubDBcontext(DbContextOptions<HubDBcontext>options):base(options)
        {
            
        }
       public DbSet<User> User {  get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.RecordedUser)
                .WithMany()
                .HasForeignKey(a => a.RecordedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
