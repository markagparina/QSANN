using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class RebarworksSlabInput : AuditableProjectEntity
    {
        public string FloorArea { get; set; }
        public string SteelbarSpacing { get; set; }
        public string SizeOfSteelbar { get; set; }
        public int OneWayOrTwoWay { get; set; }
    }
}