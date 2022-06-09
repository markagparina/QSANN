using System;

namespace QSANN.Data.Entities.Base;

public abstract class AuditableEntity
{
    public DateTime? DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime? LastUpdated { get; set; }
}
