using Microsoft.EntityFrameworkCore;
using QSANN.Data.Entities;
using QSANN.Data.Entities.Base;
using System;
using System.Linq;

namespace QSANN.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<TileworksInput> Tileworks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data source=app.db");
        }

        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();
            var added = ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in added)
            {
                if (entity is AuditableEntity)
                {
                    var track = entity as AuditableEntity;
                    track.DateCreated = DateTime.UtcNow;
                }
            }

            var modified = ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Modified)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in modified)
            {
                if (entity is AuditableEntity)
                {
                    var track = entity as AuditableEntity;
                    track.LastUpdated = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
}