using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class FormworksColumnOutput : AuditableMonitoringProjectEntity
    {
        public decimal NumberOfPlywood { get; set; }
        public decimal NumberoOfBoardFeetLumber { get; set; }

        public decimal TotalDeliveredNumberOfPlywood { get; set; }
        public decimal TotalDeliveredNumberoOfBoardFeetLumber { get; set; }
    }
}