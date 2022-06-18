using QSANN.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSANN.Data.Entities
{
    public class ConcreteOtherOutput : AuditableMonitoringProjectEntity
    {
        public decimal CementMixture { get; set; }
        public decimal Sand { get; set; }
        public decimal Gravel { get; set; }
    }
}