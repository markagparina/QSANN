using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class PaintworksInput : AuditableProjectEntity
    {
        public string AreaOfApplication { get; set; }

        public string Finish { get; set; }
    }
}