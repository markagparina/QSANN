using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class ConcreteBeamOutput : AuditableMonitoringProjectEntity
    {
        public decimal CementMixture { get; set; }
        public decimal Sand { get; set; }
        public decimal Gravel { get; set; }

        public decimal TotalDeliveredCementMixture { get; set; }
        public decimal TotalDeliveredSand { get; set; }
        public decimal TotalDeliveredGravel { get; set; }
    }
}