using Prism.Mvvm;
using System;

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

        private string _description;

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
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