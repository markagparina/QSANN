using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class RebarworksBeamInput : AuditableProjectEntity
    {
        public string LengthOfBeam { get; set; }
        public string WidthOfBeam { get; set; }
        public string HeightOfBeam { get; set; }
        public string NumbersOfBeam { get; set; }
        public string SizeOfMainbar { get; set; }
        public string SizeOfStirrups { get; set; }
    }
}