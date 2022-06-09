using QSANN.Data.Entities.Base;
using System;

namespace QSANN.Data.Entities
{
    public class Project : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}