using QSANN.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSANN.Core.Mvvm
{
    public class MonitoringViewModelBase<TEntityType> : ViewModelBase
    where TEntityType : AuditableMonitoringProjectEntity, new()
    {
    }
}