using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using QSANN.Core.Events;
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
    [Display(Name = "Carpentry Works")]
    public class CarpentryworksMonitoringViewModel : MonitoringMenuItemBase
    {
        private readonly IEventAggregator _eventAggregator;

        private DelegateCommand _updateCommand;
        public DelegateCommand UpdateCommand => _updateCommand ??= new DelegateCommand(ExecuteUpdateCommand);

        public CarpentryworksMonitoringViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, AppDbContext context) : base(regionManager, context, eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<LoadMonitoringProjectEvent>().Subscribe(LoadMonitoringProject);
        }

        public override void LoadMonitoringProject(Guid monitoringProjectId)
        {
            var projectContent = Context.Set<CarpentryWorksOutput>()
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
                            new MonitoringItemModel() { Budgeted = projectContent.Plyboard, Description = "pcs of 4'x8' Plyboard", RunningCost = 0, TotalCost = projectContent.TotalDeliveredPlyboard, PropertyName = nameof(CarpentryWorksOutput.Plyboard) },
                            new MonitoringItemModel() { Budgeted = projectContent.SizeOfLumber, Description = "bd.ft of Lumber @ 40x40 Spacing", RunningCost = 0, TotalCost = projectContent.TotalDeliveredSizeOfLumber, PropertyName = nameof(CarpentryWorksOutput.SizeOfLumber) },
                            new MonitoringItemModel() { Budgeted = projectContent.CommonWireNail, Description = "kg of Common Wire Nail", RunningCost = 0, TotalCost = projectContent.TotalDeliveredCommonWireNail, PropertyName = nameof(CarpentryWorksOutput.CommonWireNail) }
                         },
                         StorageType = typeof(CarpentryWorksOutput)
                    }
                };
            }
        }

        public override void ExecuteUpdateCommand()
        {
            Update<CarpentryWorksOutput>();
            var projectId = (Guid)Application.Current.Resources["LoadedMonitoringProject"];
            LoadMonitoringProject(projectId);
        }
    }
}