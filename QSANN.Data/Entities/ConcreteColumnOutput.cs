using QSANN.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSANN.Data.Entities
{
    public class ConcreteColumnOutput : AuditableMonitoringProjectEntity
    {
        public decimal CementMixture { get; set; }
        public decimal Sand { get; set; }
        public decimal Gravel { get; set; }

        public decimal TotalDeliveredCementMixture { get; set; }
        public decimal TotalDeliveredSand { get; set; }
        public decimal TotalDeliveredGravel { get; set; }
    }
}