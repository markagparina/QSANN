using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class RebarworksFootingInput : AuditableProjectEntity
    {
        public string LengthOfFooting { get; set; }

        public string WidthOfFooting { get; set; }

        public string NumbersOfFoooting { get; set; }

        public string SizeOfSteelbar { get; set; }

        public string SpacingOfSteelbar { get; set; }
    }
}