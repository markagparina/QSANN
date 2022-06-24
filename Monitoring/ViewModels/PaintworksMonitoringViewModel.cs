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
    [Display(Name = "Paint Works")]
    public class PaintworksMonitoringViewModel : MonitoringMenuItemBase
    {
        private DelegateCommand _updateCommand;
        public DelegateCommand UpdateCommand => _updateCommand ??= new DelegateCommand(ExecuteUpdateCommand);

        public PaintworksMonitoringViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, AppDbContext context) : base(regionManager, context, eventAggregator)
        {
        }

        public override void LoadMonitoringProject(Guid monitoringProjectId)
        {
            var projectContent = Context.Set<PaintworksOutput>()
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
                            new MonitoringItemModel() { Budgeted = projectContent.PrimerPaint, Description = "gallons of Primer Paint", RunningCost = 0, TotalCost = projectContent.TotalDeliveredPrimerPaint, PropertyName = nameof(PaintworksOutput.PrimerPaint) },
                            new MonitoringItemModel() { Budgeted = projectContent.SideBySideCoating, Description = "gallons of Coating (Side by Side)", RunningCost = 0, TotalCost = projectContent.TotalDeliveredSideBySideCoating, PropertyName = nameof(PaintworksOutput.SideBySideCoating) },
                            new MonitoringItemModel() { Budgeted = projectContent.Neutralizer, Description = "liters of Neutralizer", RunningCost = 0, TotalCost = projectContent.TotalDeliveredNeutralizer, PropertyName = nameof(PaintworksOutput.Neutralizer) }
                         },
                         StorageType = typeof(PaintworksOutput)
                    }
                };
            }
        }

        public override void ExecuteUpdateCommand()
        {
            Update<PaintworksOutput>();
            var projectId = (Guid)Application.Current.Resources["LoadedMonitoringProject"];
            LoadMonitoringProject(projectId);
        }
    }
}