using Prism.Regions;
using QSANN.Core.Mvvm;

namespace QSANN.Core.Navigation
{
    public class MenuItem : RegionViewModelBase, IMenuItem
    {
        public MenuItem(IRegionManager regionManager) : base(regionManager)
        {
        }
    }
}