using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class ConcreteFootingInput : AuditableProjectEntity
    {
        public string LengthOfFooting { get; set; }
        public string WidthOfFooting { get; set; }
        public string ThicknessOfFooting { get; set; }
        public string NumbersOfCount { get; set; }
        public string ClassMixture { get; set; }
    }
}