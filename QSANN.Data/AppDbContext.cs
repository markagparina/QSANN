using Microsoft.EntityFrameworkCore;
using QSANN.Data.Entities;
using QSANN.Data.Entities.Base;
using QSANN.Data.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace QSANN.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string specificFolder = Path.Combine(folder, "QSANN");

            Directory.CreateDirectory(specificFolder);

            optionsBuilder.UseSqlite($"Data source={specificFolder}\\app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RegisterEntitiesFromAssembly(typeof(AuditableProjectEntity).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var added = ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in added)
            {
                if (entity is AuditableProjectEntity)
                {
                    var track = entity as AuditableProjectEntity;
                    track.DateCreated = DateTime.UtcNow;
                }
            }

            var modified = ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Modified)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in modified)
            {
                if (entity is AuditableProjectEntity)
                {
                    var track = entity as AuditableProjectEntity;
                    track.LastUpdated = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
}