using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class FormworksColumnInput : AuditableProjectEntity
    {
        public string LengthOfColumn { get; set; }
        public string WidthOfColumn { get; set; }
        public string HeightOfColumn { get; set; }
        public string NumberOfCounts { get; set; }
        public string LumberSize { get; set; }
        public string ThicknessOfPlywood { get; set; }
    }
}