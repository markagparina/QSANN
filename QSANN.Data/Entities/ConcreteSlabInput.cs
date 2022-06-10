using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class ConcreteSlabInput : AuditableProjectEntity
    {
        public string LengthOfSlab { get; set; }
        public string WidthOfSlab { get; set; }
        public string ThicknessOfSlab { get; set; }
        public string NumbersOfCount { get; set; }
        public string ClassMixture { get; set; }
    }
}