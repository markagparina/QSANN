using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class MasonryInput : AuditableProjectEntity
    {
        public string HeightOfWall { get; set; }
        public string LengthOfWall { get; set; }
        public string HorizontalBarSpacing { get; set; }
        public string VerticalBarSpacing { get; set; }
        public string ClassMixtureForMortar { get; set; }
        public string ClassMixtureForPlaster { get; set; }
        public string ThicknessInMillimeter { get; set; }
    }
}