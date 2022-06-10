using QSANN.Data.Entities.Base;
using System;

namespace QSANN.Data.Entities
{
    public class TileworksInput : AuditableProjectEntity
    {
        public string AreaOfWorkDesignation { get; set; }
        public string SelectedMultiplier { get; set; }
    }
}