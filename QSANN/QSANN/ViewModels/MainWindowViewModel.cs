using CategoriesModule;
using CategoriesModule.Dialogs;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism.Unity;
using QSANN.Core;
using QSANN.Core.Mvvm;
using QSANN.Core.Navigation;
using QSANN.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QSANN.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;
        public List<MenuItemModel> AllMenuItems { get; set; }

        private ObservableCollection<MenuItemModel> _menuItems;

        public ObservableCollection<MenuItemModel> MenuItems
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

        private bool _isSaveMode;

        public bool IsSaveMode
        {
            get { return _isSaveMode; }
            set { SetProperty(ref _isSaveMode, value); }
        }

        private MenuItemModel _selectedItem;

        public MenuItemModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (SetProperty(ref _selectedItem, value) && value is not null)
                {
                    IsMenuOpen = false;

                    var viewName = value.ViewModelName.Replace("Model", "");

                    if (value is not null)
                    {
                        _regionManager.RequestNavigate(RegionNames.MainContentRegion, viewName);
                    }
                }
            }
        }

        public ProjectDialogViewModel ProjectViewModel { get; private set; }

        private string _searchKeyword;

        public string SearchKeyword
        {
            get { return _searchKeyword; }
            set { SetProperty(ref _searchKeyword, value, () => FilterCategories()); }
        }

        private bool _isMainWindowDialogOpen;

        public bool IsMainWindowDialogOpen
        {
            get { return _isMainWindowDialogOpen; }
            set { SetProperty(ref _isMainWindowDialogOpen, value); }
        }

        private DelegateCommand _saveProjectCommand;
        public DelegateCommand SaveProjectCommand => _saveProjectCommand ??= new DelegateCommand(ExecuteSaveProjectCommand);

        private DelegateCommand _loadProjectCommand;
        public DelegateCommand LoadProjectCommand => _loadProjectCommand ??= new DelegateCommand(async () => await ExecuteLoadProjectCommandAsync());

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            var menuTypes = typeof(QSANNCategoriesModule).Assembly.GetExportedTypes().Where(type => type.IsAssignableTo(typeof(MenuItem)));
            var container = PrismContainerExtension.Current;
            AllMenuItems = menuTypes.Select(item =>
            {
                var attribute = (DisplayAttribute)Array.Find(item.GetCustomAttributes(typeof(DisplayAttribute), false), a => (a is DisplayAttribute));

                return new MenuItemModel() { ViewModelName = item.Name, Title = attribute.Name };
            }).ToList();
            MenuItems = new(AllMenuItems);
            SelectedItem = AllMenuItems[0];

            ProjectViewModel = container.Resolve<ProjectDialogViewModel>();
            ProjectViewModel.ExecuteLoadedCommandAsync().Await();
        }

        private object FilterCategories()
        {
            MenuItems = new(AllMenuItems.Where(item => string.IsNullOrEmpty(SearchKeyword) || item.Title.Contains(SearchKeyword, StringComparison.OrdinalIgnoreCase)));

            return MenuItems;
        }

        private Task ExecuteLoadProjectCommandAsync()
        {
            IsSaveMode = false;
            IsMainWindowDialogOpen = true;
            return Task.CompletedTask;
        }

        private void ExecuteSaveProjectCommand()
        {
            IsSaveMode = true;
            IsMainWindowDialogOpen = true;
        }
    }
}