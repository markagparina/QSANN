using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class MasonryOutput : AuditableMonitoringProjectEntity
    {
        public decimal ConcreteHollowBlocks { get; set; }
        public decimal Cement { get; set; }
        public decimal Sand { get; set; }
        public decimal HorizontalBars { get; set; }
        public decimal VerticalBars { get; set; }


        public decimal TotalDeliveredConcreteHollowBlocks { get; set; }
        public decimal TotalDeliveredCement { get; set; }
        public decimal TotalDeliveredSand { get; set; }
        public decimal TotalDeliveredHorizontalBars { get; set; }
        public decimal TotalDeliveredVerticalBars { get; set; }
    }
}