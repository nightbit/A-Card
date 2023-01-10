using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MySql.EntityFrameworkCore.Extensions;

namespace A_Card_Server.Models
{
	public class ACardContext : DbContext
	{
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public ACardContext(DbContextOptions<ACardContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.uuid);
                entity.Property(e => e.name);
                entity.Property(e => e.species);
                entity.Property(e => e.birthday);
                entity.Property(e => e.chip);
                entity.HasOne(e => e.owner);
            });
            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => e.ssn);
                entity.Property(e => e.firstname);
                entity.Property(e => e.lastname);
                entity.Property(e => e.email);
                entity.Property(e => e.phone);
                entity.Property(e => e.password);
                entity.Property(e => e.birthday);
                entity.Property(e => e.streetAndNumber);
                entity.Property(e => e.zip);
                entity.Property(e => e.city);
                entity.Property(e => e.country);
                entity.HasMany(e => e.Animals);
            });
        }

    }
}

