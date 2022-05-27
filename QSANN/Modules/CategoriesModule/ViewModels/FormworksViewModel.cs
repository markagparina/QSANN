using Prism.Regions;
using QSANN.Core.Navigation;

namespace CategoriesModule.ViewModels
{
    public class FormworksViewModel : MenuItem
    {
        public FormworksViewModel(IRegionManager regionManager) : base(regionManager)
        {
        }

        public override string Title => "Formworks";

    }
}
