using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using QSANN.Core.Models;
using QSANN.Core.Mvvm;
using QSANN.Data;
using QSANN.Data.Entities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;

namespace Monitoring.ViewModels
{
    [Display(Name = "Tile Works")]
    public class TileworksMonitoringViewModel : MonitoringMenuItemBase
    {
        private DelegateCommand _updateCommand;
        public DelegateCommand UpdateCommand => _updateCommand ??= new DelegateCommand(ExecuteUpdateCommand);

        public TileworksMonitoringViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, AppDbContext context) : base(regionManager, context, eventAggregator)
        {
        }

        public override void LoadMonitoringProject(Guid monitoringProjectId)
        {
            var projectContent = Context.Set<TileworksOutput>()
                            .FirstOrDefault(proj => proj.MonitoringProjectId == monitoringProjectId);

            if (projectContent is not null)
            {
                Categories = new()
                {
                    new MonitoringCategoryModel()
                    {
                         Name = "",
                         MonitoringItems = new ObservableCollection<MonitoringItemModel>()
                         {
                            new MonitoringItemModel() { Budgeted = projectContent.NumberOfPieces, Description = "number of pieces", RunningCost = 0, TotalCost = projectContent.TotalDeliveredNumberOfPieces, PropertyName = nameof(TileworksOutput.NumberOfPieces) },
                            new MonitoringItemModel() { Budgeted = projectContent.NumberOf40KgBagsOfCement, Description = "number of 40kg. Bag of Cement", RunningCost = 0, TotalCost = projectContent.TotalDeliveredNumberOf40KgBagsOfCement, PropertyName = nameof(TileworksOutput.NumberOf40KgBagsOfCement) },
                            new MonitoringItemModel() { Budgeted = projectContent.NumberOfBagOfAdhesive, Description = "number of bag of Adhesive", RunningCost = 0, TotalCost = projectContent.TotalDeliveredNumberOfBagOfAdhesive, PropertyName = nameof(TileworksOutput.NumberOfBagOfAdhesive) },
                            new MonitoringItemModel() { Budgeted = projectContent.NumberOfKgOfGrout, Description = "kg/s of grout", RunningCost = 0, TotalCost = projectContent.TotalDeliveredNumberOfKgOfGrout, PropertyName = nameof(TileworksOutput.NumberOfKgOfGrout) }
                         },
                         StorageType = typeof(TileworksOutput)
                    }
                };
            }
        }

        public override void ExecuteUpdateCommand()
        {
            Update<TileworksOutput>();
            var projectId = (Guid)Application.Current.Resources["LoadedMonitoringProject"];
            LoadMonitoringProject(projectId);
        }
    }
}