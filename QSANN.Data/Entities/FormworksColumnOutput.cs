using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class FormworksColumnOutput : AuditableMonitoringProjectEntity
    {
        public decimal NumberOfPlywood { get; set; }
        public decimal NumberOfBoardFeetLumber { get; set; }

        public decimal TotalDeliveredNumberOfPlywood { get; set; }
        public decimal TotalDeliveredNumberOfBoardFeetLumber { get; set; }
    }
}