using QSANN.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSANN.Data.Entities
{
    public class MonitoringProject : AuditableEntity
    {
        public string Name { get; set; }
    }
}
