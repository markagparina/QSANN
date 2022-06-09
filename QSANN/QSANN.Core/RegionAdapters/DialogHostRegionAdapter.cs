using MaterialDesignThemes.Wpf;
using Prism.Regions;

namespace QSANN.Core.RegionAdapters
{
    public class DialogHostRegionAdapter : RegionAdapterBase<DialogHost>
    {
        public DialogHostRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, DialogHost regionTarget)
        {
        }

        protected override IRegion CreateRegion()
        {
            throw new System.NotImplementedException();
        }
    }
}