using Monitoring;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
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
    public class MonitoringViewModel : ViewModelBase
    {
        public List<MenuItemModel> AllMenuItems { get; set; }

        private ObservableCollection<MenuItemModel> _menuItems;

        public ObservableCollection<MenuItemModel> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        private string _title = "QSuMM";

        public override string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, string.IsNullOrEmpty(value) ? "QSuMM" : value); }
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

        private bool _isMonitoringWindowDialogOpen;

        public bool IsMonitoringWindowDialogOpen
        {
            get { return _isMonitoringWindowDialogOpen; }
            set { SetProperty(ref _isMonitoringWindowDialogOpen, value); }
        }

        private MenuItemModel _selectedItem;
        private readonly IRegionManager _regionManager;

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
                        _regionManager.RequestNavigate(RegionNames.MonitoringContentRegion, viewName);
                    }
                }
            }
        }

        public MonitoringProjectViewModel ProjectViewModel { get; private set; }

        private DelegateCommand _backToMainMenuCommand;
        public DelegateCommand BackToMainMenuCommand => _backToMainMenuCommand ??= new DelegateCommand(ExecuteBackToMainMenuCommand);

        private DelegateCommand _loadProjectCommand;
        public DelegateCommand LoadProjectCommand => _loadProjectCommand ??= new DelegateCommand(ExecuteLoadProjectCommand);

        public MonitoringViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            var menuTypes = typeof(MonitoringModule).Assembly.GetExportedTypes().Where(type => type.IsAssignableTo(typeof(MenuItem)));
            var container = PrismContainerExtension.Current;
            AllMenuItems = menuTypes.Select(item =>
            {
                var attribute = (DisplayAttribute)Array.Find(item.GetCustomAttributes(typeof(DisplayAttribute), false), a => (a is DisplayAttribute));

                return new MenuItemModel() { ViewModelName = item.Name, Title = attribute.Name };
            }).ToList();
            MenuItems = new(AllMenuItems);
            SelectedItem = AllMenuItems[0];

            ProjectViewModel = container.Resolve<MonitoringProjectViewModel>();
            ProjectViewModel.ExecuteLoadedCommandAsync().Await();
        }

        private void ExecuteBackToMainMenuCommand()
        {
            _regionManager.RequestNavigate(RegionNames.ModuleRegion, "HomeView");
        }

        private async void ExecuteLoadProjectCommand()
        {
            await ExecuteLoadProjectCommandAsync();
        }

        private async Task ExecuteLoadProjectCommandAsync()
        {
            IsSaveMode = false;
            IsMonitoringWindowDialogOpen = true;
            await ProjectViewModel.ExecuteLoadedCommandAsync();
        }
    }
}