using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class RebarworksFootingOutput : AuditableMonitoringProjectEntity
    {
        public decimal Steelbar { get; set; }
        public decimal Tiewire { get; set; }

        public decimal TotalDeliveredSteelbar { get; set; }
        public decimal TotalDeliveredTiewire { get; set; }
    }
}