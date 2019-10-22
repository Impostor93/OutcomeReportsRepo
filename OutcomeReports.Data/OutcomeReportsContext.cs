using Microsoft.EntityFrameworkCore;
using OutcomeReports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutcomeReports.Data
{
    public class OutcomeReportsContext : DbContext
    {
        private string dbPath;
        
        public OutcomeReportsContext(string dbPath)
        {
            
            //IOS
            //var dbname = "OutcomeReports.sqlite"
            //var path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "..","Library", "data")
            //if(!Directory.Exist(path))
            //{ Directory.CreateDirectory(path) }
            //var connectionString = Path.Combine(path, dbname)
            //INITIALIZE SQLITE
            this.dbPath = dbPath;
        }

        public DbSet<Period> Periods { get; set; }

        public DbSet<Line> Lines { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"FileName={dbPath}");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Period>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Period>()
                .Property(e => e.Start).IsRequired(true);
            modelBuilder.Entity<Period>()
                .Property(e => e.End).IsRequired(true);

            modelBuilder.Entity<Line>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Line>()
                .Property(e => e.PeriodId).IsRequired(true);
            modelBuilder.Entity<Line>()
                .Property(e => e.Amount).IsRequired(true);
            modelBuilder.Entity<Line>()
                .Property(e => e.CategoryId).IsRequired(true);
            modelBuilder.Entity<Line>()
                .Property(e => e.Date).IsRequired(true);

            modelBuilder.Entity<Category>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Category>()
                .Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
