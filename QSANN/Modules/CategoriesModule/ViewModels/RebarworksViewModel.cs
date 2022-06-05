using Prism.Mvvm;
using Prism.Regions;
using QSANN.Core.Navigation;

namespace CategoriesModule.ViewModels
{
    public class RebarworksViewModel : MenuItem
    {

        public override string Title => "Rebarworks";

        public RebarworksViewModel(IRegionManager regionManager) : base(regionManager)
        {
        }
    
    }
}
