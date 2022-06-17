using QSANN.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QSANN.Data.Extensions
{
    public static class EntityExtensions
    {
        public static List<Type> GetEntitiesFromAssembly(this Assembly assembly, Type assignableType)
        {
            return assembly.ExportedTypes
                    .Where(type => !type.IsAbstract
                                && !type.IsInterface
                                && type.IsAssignableTo(typeof(AuditableProjectEntity))).ToList();
        }
    }
}