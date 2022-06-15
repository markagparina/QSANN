using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriesModule.Models
{
    public class OtherMaterialModel : BindableBase
    {
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _itemName;

        public string ItemName
        {
            get { return _itemName; }
            set { SetProperty(ref _itemName, value); }
        }

        private string _constructionScope;

        public string ConstructionScope
        {
            get { return _constructionScope; }
            set { SetProperty(ref _constructionScope, value); }
        }

        private string _quantity;

        public string Quantity
        {
            get { return _quantity; }
            set { SetProperty(ref _quantity, value); }
        }
    }
}