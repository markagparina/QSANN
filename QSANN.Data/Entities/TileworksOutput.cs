using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class TileworksOutput : AuditableMonitoringProjectEntity
    {
        public decimal NumberOfPieces { get; set; }
        public decimal NumberOf40KgBagsOfCement { get; set; }
        public decimal NumberOfBagOfAdhesive { get; set; }
        public decimal NumberOfKgOfGrout { get; set; }

        public decimal TotalDeliveredNumberOfPieces { get; set; }
        public decimal TotalDeliveredNumberOf40KgBagsOfCement { get; set; }
        public decimal TotalDeliveredNumberOfBagOfAdhesive { get; set; }
        public decimal TotalDeliveredNumberOfKgOfGrout { get; set; }
    }
}