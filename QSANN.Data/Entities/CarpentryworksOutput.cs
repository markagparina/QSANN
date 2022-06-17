using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class CarpentryWorksOutput : AuditableMonitoringProjectEntity
    {
        public decimal Plyboard { get; set; }
        public decimal SizeOfLumber { get; set; }
        public decimal CommonWireNail { get; set; }

        public decimal TotalDeliveredPlyboard { get; set; }
        public decimal TotalDeliveredSizeOfLumber { get; set; }
        public decimal TotalDeliveredCommonWireNail { get; set; }
    }
}