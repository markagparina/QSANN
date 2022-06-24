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
    [Display(Name = "Masonry")]
    public class MasonryMonitoringViewModel : MonitoringMenuItemBase
    {
        private readonly IEventAggregator _eventAggregator;

        private DelegateCommand _updateCommand;
        public DelegateCommand UpdateCommand => _updateCommand ??= new DelegateCommand(ExecuteUpdateCommand);

        public MasonryMonitoringViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, AppDbContext context) : base(regionManager, context, eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<LoadMonitoringProjectEvent>().Subscribe(LoadMonitoringProject);
        }

        public override void LoadMonitoringProject(Guid monitoringProjectId)
        {
            var projectContent = Context.Set<MasonryOutput>()
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
                                new MonitoringItemModel() { Budgeted = projectContent.ConcreteHollowBlocks, Description = "pcs of Hollowblocks", RunningCost = 0, TotalCost = projectContent.TotalDeliveredConcreteHollowBlocks, PropertyName = nameof(MasonryOutput.ConcreteHollowBlocks) },
                                new MonitoringItemModel() { Budgeted = projectContent.Cement, Description = "Bags of Cement", RunningCost = 0, TotalCost = projectContent.TotalDeliveredCement, PropertyName = nameof(MasonryOutput.Cement) },
                                new MonitoringItemModel() { Budgeted = projectContent.Sand, Description = "m\xB3 of Sand", RunningCost = 0, TotalCost = projectContent.TotalDeliveredSand, PropertyName = nameof(MasonryOutput.Sand) },
                                new MonitoringItemModel() { Budgeted = projectContent.HorizontalBars, Description = "pieces of 6 meter Horizontal Bars", RunningCost = 0, TotalCost = projectContent.TotalDeliveredHorizontalBars, PropertyName = nameof(MasonryOutput.HorizontalBars) },
                                new MonitoringItemModel() { Budgeted = projectContent.VerticalBars, Description = "pieces of 6 meter Vertical Bars", RunningCost = 0, TotalCost = projectContent.TotalDeliveredVerticalBars, PropertyName = nameof(MasonryOutput.VerticalBars) }
                             },
                             StorageType = typeof(MasonryOutput)
                        }
                    };
            }
        }

        public override void ExecuteUpdateCommand()
        {
            Update<MasonryOutput>();
            var projectId = (Guid)Application.Current.Resources["LoadedMonitoringProject"];
            LoadMonitoringProject(projectId);
        }
    }
}