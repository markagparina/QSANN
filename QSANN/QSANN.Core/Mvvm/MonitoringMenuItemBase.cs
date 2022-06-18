using Prism.Regions;
using QSANN.Core.Navigation;
using QSANN.Data.Entities.Base;

namespace QSANN.Core.Mvvm
{
    public class MonitoringMenuItemBase<TEntityType> : MenuItem
    where TEntityType : AuditableMonitoringProjectEntity, new()
    {
        public MonitoringMenuItemBase(IRegionManager regionManager) : base(regionManager)
        {
        }
    }
}