using Monitoring;
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
                        _regionManager.RequestNavigate(RegionNames.MainContentRegion, viewName);
                    }
                }
            }
        }

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

            //ProjectViewModel = container.Resolve<ProjectDialogViewModel>();
            //ProjectViewModel.ExecuteLoadedCommandAsync().Await();
        }
    }
}