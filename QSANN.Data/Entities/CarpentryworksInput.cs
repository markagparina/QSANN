using QSANN.Data.Entities.Base;

namespace QSANN.Data.Entities
{
    public class CarpentryworksInput : AuditableProjectEntity
    {
        public string AreaOfDesignation { get; set; }
        public string SizeOfLumber { get; set; }
    }
}