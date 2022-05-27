using Prism.Regions;
using QSANN.Core.Navigation;

namespace CategoriesModule.ViewModels
{
    public class CementViewModel : MenuItem
    {
        public CementViewModel(IRegionManager regionManager) : base(regionManager)
        {
        }

        public override string Title => "Cement";

    }
}
