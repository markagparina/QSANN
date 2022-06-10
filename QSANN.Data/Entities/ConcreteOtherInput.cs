using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class ConcreteOtherInput : AuditableProjectEntity
    {
        public string TotalVolume { get; set; }
        public string NumbersOfCount { get; set; }
        public string ClassMixture { get; set; }
    }
}