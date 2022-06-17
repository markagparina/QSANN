using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class PaintworksOutput : AuditableMonitoringProjectEntity
    {
        public decimal PrimerPaint { get; set; }
        public decimal SideBySideCoating { get; set; }
        public decimal Neutralizer { get; set; }


        public decimal TotalDeliveredPrimerPaint { get; set; }
        public decimal TotalDeliveredSideBySideCoating { get; set; }
        public decimal TotalDeliveredNeutralizer { get; set; }
    }
}