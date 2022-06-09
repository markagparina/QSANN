using QSANN.Data.Entities.Base;
using System;

namespace QSANN.Data.Entities
{
    public class TileworksInput : AuditableEntity
    {
        public Guid Id { get; set; }
        public string AreaOfWorkDesignation { get; set; }
        public string SelectedMultiplier { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}