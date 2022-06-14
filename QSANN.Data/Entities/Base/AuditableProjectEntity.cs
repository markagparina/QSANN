using QSANN.Data.Attributes;
using System;

namespace QSANN.Data.Entities.Base;

public abstract class AuditableProjectEntity : AuditableEntity
{
    [MappingIgnored]
    public Project Project { get; set; }

    public Guid ProjectId { get; set; }
}