using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class FormworksBeamInput : AuditableProjectEntity
    {
        public string LengthOfBeam { get; set; }
        public string WidthOfBeam { get; set; }
        public string HeightOfBeam { get; set; }
        public string NumberOfCounts { get; set; }
        public string LumberSize { get; set; }
        public string ThicknessOfPlywood { get; set; }
    }
}