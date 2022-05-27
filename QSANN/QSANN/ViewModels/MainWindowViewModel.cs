using CategoriesModule;
using Prism.Regions;
using Prism.Unity;
using QSANN.Core;
using QSANN.Core.Mvvm;
using QSANN.Core.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace QSANN.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public List<MenuItem> AllMenuItems { get; set; } = new List<MenuItem>();

        private ObservableCollection<MenuItem> _menuItems;
        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        private string _title = "QSANN";
        public override string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, string.IsNullOrEmpty(value) ? "QSANN" : value); }
        }


        private bool _isMenuOpen;
        public bool IsMenuOpen
        {
            get => _isMenuOpen;
            set => SetProperty(ref _isMenuOpen, value);
        }

        private MenuItem _selectedItem;
        private readonly IRegionManager _regionManager;

        public MenuItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (SetProperty(ref _selectedItem, value))
                {
                    IsMenuOpen = false;

                    if (value is not null)
                    {
                        _regionManager.RequestNavigate(RegionNames.ContentRegion, $"{value.Title}View");
                    }
                }
            }
        }

        private string _searchKeyword;
        public string SearchKeyword
        {
            get { return _searchKeyword; }
            set { SetProperty(ref _searchKeyword, value, () => FilterCategories()); }
        }


        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            var menuTypes = typeof(QSANNCategoriesModule).Assembly.GetExportedTypes().Where(type => type.IsAssignableTo(typeof(MenuItem)));
            var container = PrismContainerExtension.Current;
            AllMenuItems = menuTypes.Select(item => (MenuItem)container.Resolve(item)).ToList();
            MenuItems = new(AllMenuItems);
            SelectedItem = AllMenuItems[0];
        }

        private object FilterCategories()
        {
            MenuItems = new(AllMenuItems.Where(item => string.IsNullOrEmpty(SearchKeyword) || item.Title.Contains(SearchKeyword, StringComparison.OrdinalIgnoreCase)));

            return MenuItems;
        }
    }
}
