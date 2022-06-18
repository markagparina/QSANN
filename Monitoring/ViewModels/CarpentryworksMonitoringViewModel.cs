using Monitoring.Models;
using Prism.Regions;
using QSANN.Core.Mvvm;
using QSANN.Core.Navigation;
using QSANN.Data.Entities;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Monitoring.ViewModels
{
    [Display(Name = "Carpentry Works")]
    public class CarpentryworksMonitoringViewModel : MonitoringMenuItemBase<CarpentryWorksOutput>
    {
        private ObservableCollection<MonitoringCategoryModel> _categories;

        public ObservableCollection<MonitoringCategoryModel> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
        }

        public CarpentryworksMonitoringViewModel(IRegionManager regionManager) : base(regionManager)
        {
            Categories = new ObservableCollection<MonitoringCategoryModel>()
            {
                new MonitoringCategoryModel()
                {
                     Name = "Carpentry Works",
                     MonitoringItems = new ObservableCollection<MonitoringItemModel>()
                     {
                        new MonitoringItemModel() { Budgeted = 3, Description = "pcs of 4'x8' Plyboard", RunningCost = 0, TotalCost = 2 },
                        new MonitoringItemModel() { Budgeted = 5, Description = "bd.ft of Lumber @ 40x40 Spacing", RunningCost = 0, TotalCost = 2 },
                        new MonitoringItemModel() { Budgeted = 10, Description = "kg of Common Wire Nail", RunningCost = 0, TotalCost = 5 }
                     }
                }
            };
        }
    }
}