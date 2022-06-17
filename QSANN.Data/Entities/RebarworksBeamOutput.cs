using QSANN.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSANN.Data.Entities
{
    public class RebarworksBeamOutput : AuditableMonitoringProjectEntity
    {
        public decimal Mainbar { get; set; }
        public decimal ShortBeamLength { get; set; }
        public decimal Tiewire { get; set; }
        public decimal LateralTies { get; set; }


        public decimal TotalDeliveredMainbar { get; set; }
        public decimal TotalDeliveredShortBeamLength { get; set; }
        public decimal TotalDeliveredTiewire { get; set; }
        public decimal TotalDeliveredLateralTies { get; set; }
    }
}