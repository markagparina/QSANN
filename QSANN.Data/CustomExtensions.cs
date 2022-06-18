using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace QSANN.Data
{


    namespace Microsoft.EntityFrameworkCore
    {
        public static partial class CustomExtensions
        {
            public static IQueryable Query(this DbContext context, string entityName) =>
                context.Query(context.Model.FindEntityType(entityName).ClrType);

            static readonly MethodInfo SetMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes);

            public static IQueryable Query(this DbContext context, Type entityType) =>
                (IQueryable)SetMethod.MakeGenericMethod(entityType).Invoke(context, null);
        }
    }
}
