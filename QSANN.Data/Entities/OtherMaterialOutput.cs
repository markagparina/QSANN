using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class OtherMaterialOutput : AuditableMonitoringProjectEntity
    {
        public string ItemName { get; set; }
        public string ConstructionScope { get; set; }
        public decimal Quantity { get; set; }
        public decimal RunningCost { get; set; }
    }
}