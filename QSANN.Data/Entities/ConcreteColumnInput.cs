using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class ConcreteColumnInput : AuditableProjectEntity
    {
        public string LengthOfColumn { get; set; }
        public string WidthOfColumn { get; set; }
        public string HeightOfColumn { get; set; }
        public string NumbersOfCount { get; set; }
        public string ClassMixture { get; set; }
    }
}