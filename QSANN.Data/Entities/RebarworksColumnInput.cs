using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class RebarworksColumnInput : AuditableProjectEntity
    {
        public string LengthOfColumn { get; set; }
        public string WidthOfColumn { get; set; }
        public string HeightOfColumn { get; set; }
        public string NumbersOfColumn { get; set; }
        public string SizeOfMainBar { get; set; }
        public string SizeOfLateralties { get; set; }

    }
}

