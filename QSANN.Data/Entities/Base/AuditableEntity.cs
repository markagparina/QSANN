using QSANN.Data.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSANN.Data.Entities.Base
{
    public class AuditableEntity
    {
        [MappingIgnored]
        public Guid Id { get; set; }

        [MappingIgnored]
        public DateTime? DateCreated { get; set; } = DateTime.UtcNow;

        [MappingIgnored]
        public DateTime? LastUpdated { get; set; }
    }
}