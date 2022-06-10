using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class ConcreteBeamInput : AuditableProjectEntity
    {
        public string LengthOfBeam { get; set; }
        public string WidthOfBeam { get; set; }
        public string HeightOfBeam { get; set; }
        public string NumbersOfCount { get; set; }
        public string ClassMixture { get; set; }
    }
}