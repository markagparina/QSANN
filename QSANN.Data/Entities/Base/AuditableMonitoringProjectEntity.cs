using QSANN.Data.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSANN.Data.Entities.Base
{
    public class AuditableMonitoringProjectEntity : AuditableEntity
    {
        [MappingIgnored]
        public MonitoringProject MonitoringProject { get; set; }

        public Guid MonitoringProjectId { get; set; }
    }
}
