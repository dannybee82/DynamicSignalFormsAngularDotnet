using Microsoft.EntityFrameworkCore;
using RepositoryLayer.DummyData;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class MainDbContext : DbContext
    {
        public DbSet<SignalForm> SignalForms { get; set; }

        public DbSet<SignalFormField> SignalFormFields { get; set; }

        public DbSet<SignalFormValidation> SignalFormValidations { get; set; }

        public DbSet<SignalFormOption> SignalFormOptions { get; set; }

        public DbSet<SignalFormAdditionalData> SignalFormAdditionalData { get; set; }


        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SignalForm>()
                .HasMany(x => x.FormFields)
                .WithOne(x => x.SignalForm)
                .HasForeignKey(sff => sff.SignalFormId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SignalFormField>()
                .HasMany(x => x.Validations)
                .WithOne(x => x.SignalFormField)
                .HasForeignKey(ssf => ssf.SignalFormFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SignalFormField>()
                .HasMany(x => x.Options)
                .WithOne(x => x.SignalFormField)
                .HasForeignKey(ssf => ssf.SignalFormFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SignalFormField>()
                .HasMany(x => x.AddionalData)
                .WithOne(x => x.SignalFormField)
                .HasForeignKey(ssf => ssf.SignalFormFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SignalForm>().HasData(
                DummyDataSignalForms.Create()
            );

            modelBuilder.Entity<SignalFormField>().HasData(
                DummyDataSignalFormFields.Create()
            );

            modelBuilder.Entity<SignalFormValidation>().HasData(
                DummyDataSignalFormValidations.Create()
            );

            modelBuilder.Entity<SignalFormOption>().HasData(
                DummyDataSignalFormOptions.Create()
            );

            modelBuilder.Entity<SignalFormAdditionalData>().HasData(
               DummyDataSignalFormAdditionalData.Create()
           );
        }

    }

}