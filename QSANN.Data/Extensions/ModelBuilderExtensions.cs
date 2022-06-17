using Humanizer;
using Microsoft.EntityFrameworkCore;
using QSANN.Data.Entities.Base;
using System.Reflection;

namespace QSANN.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void RegisterEntitiesFromAssembly(this ModelBuilder builder, Assembly assembly)
        {
            var entityTypes = assembly.GetEntitiesFromAssembly(typeof(AuditableProjectEntity));
            var monitoringEntityTypes = assembly.GetEntitiesFromAssembly(typeof(AuditableMonitoringProjectEntity));

            entityTypes.ForEach(entity => builder.Entity(entity)
                                                 .ToTable(entity.Name.Pluralize(inputIsKnownToBeSingular: false)));

            monitoringEntityTypes.ForEach(entity => builder.Entity(entity)
                                                         .ToTable(entity.Name.Pluralize(inputIsKnownToBeSingular: false)));
        }
    }
}