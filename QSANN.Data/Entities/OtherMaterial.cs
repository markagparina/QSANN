using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class OtherMaterial : AuditableProjectEntity
    {
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string ConstructionScope { get; set; }
        public string Quantity { get; set; }
    }
}