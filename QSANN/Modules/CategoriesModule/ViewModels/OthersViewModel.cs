using CategoriesModule.Models;
using Prism.Commands;
using Prism.Regions;
using QSANN.Core.Navigation;
using System;
using System.Collections.ObjectModel;

namespace CategoriesModule.ViewModels
{
    public class OthersViewModel : MenuItem
    {
        private ObservableCollection<OtherMaterialModel> _otherMaterials;
        private ObservableCollection<string> _constructionScopes;

        public override string Title => "Other Materials";

        public ObservableCollection<OtherMaterialModel> OtherMaterials { get => _otherMaterials; set => SetProperty(ref _otherMaterials, value); }
        public ObservableCollection<string> ConstructionScopes { get => _constructionScopes; set => _constructionScopes = value; }

        private DelegateCommand _addNewItemCommand;
        public DelegateCommand AddNewItemCommand => _addNewItemCommand ??= new DelegateCommand(AddNewItem);



        private DelegateCommand _removeLastItemCommand;


        public DelegateCommand RemoveLastItemCommand => _removeLastItemCommand ??= new DelegateCommand(RemoveLastItem);

        private void RemoveLastItem()
        {
            if (OtherMaterials.Count > 0)
            {
                OtherMaterials.RemoveAt(OtherMaterials.Count - 1);
            }
        }

        public OthersViewModel(IRegionManager regionManager) : base(regionManager)
        {
            OtherMaterials = new();
            ConstructionScopes = new()
            {
                "Mobilization",
                "Rebar Works",
                "Masonry Works",
                "Plumbing Works",
                "Roofing / Trusses & Metalworks",
                "Electrical Works",
                "Paint Works",
                "Tile Works",
                "Carpentry",
                "Demobilization",
                "Formworks",
                "Fence",
                "Finishing Materials",
                "Consumables",
                "Electrical Devices",
                "Gate and Fence Metal Works",
                "Finishing Materials",
                "Consumables",
                "Electrical Devices",
                "Plumbing Fixtures"
            };
        }

        private void AddNewItem()
        {
            OtherMaterials.Add(new OtherMaterialModel());
        }
    }
}
