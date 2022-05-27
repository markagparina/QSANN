using Prism.Mvvm;
using Prism.Navigation;

namespace QSANN.Core.Mvvm
{
    public abstract class ViewModelBase : BindableBase, IDestructible
    {
        private string _String;
        public virtual string Title
        {
            get { return _String; }
            set { SetProperty(ref _String, value); }
        }

        protected ViewModelBase()
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
