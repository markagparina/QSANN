using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class RebarworksColumnOutput : AuditableMonitoringProjectEntity
    {
        public decimal Mainbar { get; set; }
        public decimal Tiewire { get; set; }
        public decimal LateralTies { get; set; }


        public decimal TotalDeliveredMainbar { get; set; }
        public decimal TotalDeliveredTiewire { get; set; }
        public decimal TotalDeliveredLateralTies { get; set; }
    }
}