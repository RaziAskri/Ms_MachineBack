using Microsoft.EntityFrameworkCore;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Models;
using System;

  


namespace Ms_Machine.Domain.Poulina.MSmachine.Domain.Data
{
    public class PoulinaDbContext : DbContext
    {
        public PoulinaDbContext()
        {
        }
        public PoulinaDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<Fournisseur> Fournisserurs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Filiaire> Filiaires { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Machine>().ToTable("Machine");
            modelBuilder.Entity<Fournisseur>().ToTable("Frournisseur");
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<Filiaire>().ToTable("Filiaire");


            modelBuilder.Entity<Machine>()
                           .HasOne(fr => fr.Fournisseur)
                           .WithMany(mc => mc.Machines)
                           .HasForeignKey(pr => pr.id_fournisseur);

            modelBuilder.Entity<Service>()
                           .HasOne(f => f.Filiaire)
                           .WithMany(sc => sc.Services)
                           .HasForeignKey(pr => pr.id_filiaire);



        }

    }
}
