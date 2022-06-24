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
    [Display(Name = "Rebarworks")]
    public class RebarworksMonitoringViewModel : MonitoringMenuItemBase
    {
        private DelegateCommand _updateCommand;
        public DelegateCommand UpdateCommand => _updateCommand ??= new DelegateCommand(ExecuteUpdateCommand);

        public RebarworksMonitoringViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, AppDbContext context) : base(regionManager, context, eventAggregator)
        {
        }

        public override void LoadMonitoringProject(Guid monitoringProjectId)
        {
            Categories.Clear();
            LoadColumnContent(monitoringProjectId);
            LoadBeamContent(monitoringProjectId);
            LoadFootingContent(monitoringProjectId);
            LoadSlabContent(monitoringProjectId);
        }

        private void LoadColumnContent(Guid monitoringProjectId)
        {
            var columnContent = Context.Set<RebarworksColumnOutput>()
                .FirstOrDefault(proj => proj.MonitoringProjectId == monitoringProjectId);
            if (columnContent is not null)
            {
                Categories.Add(new MonitoringCategoryModel()
                {
                    Name = "Column",
                    MonitoringItems = new ObservableCollection<MonitoringItemModel>()
                         {
                            new MonitoringItemModel() { Budgeted = columnContent.Mainbar, Description = "pcs of 6m Mainbar", RunningCost = 0, TotalCost = columnContent.TotalDeliveredMainbar, PropertyName = nameof(RebarworksColumnOutput.Mainbar) },
                            new MonitoringItemModel() { Budgeted = columnContent.LateralTies, Description = "pcs of 6m Lateral Ties", RunningCost = 0, TotalCost = columnContent.TotalDeliveredLateralTies, PropertyName = nameof(RebarworksColumnOutput.LateralTies) },
                            new MonitoringItemModel() { Budgeted = columnContent.Tiewire, Description = "kg/s of (#16) Tiewire", RunningCost = 0, TotalCost = columnContent.TotalDeliveredTiewire, PropertyName = nameof(RebarworksColumnOutput.Tiewire) }
                         },
                    StorageType = typeof(RebarworksColumnOutput)
                });
            }
        }

        private void LoadBeamContent(Guid monitoringProjectId)
        {
            var beamContent = Context.Set<RebarworksBeamOutput>()
                .FirstOrDefault(proj => proj.MonitoringProjectId == monitoringProjectId);
            if (beamContent is not null)
            {
                Categories.Add(new MonitoringCategoryModel()
                {
                    Name = "Beam",
                    MonitoringItems = new ObservableCollection<MonitoringItemModel>()
                         {
                            new MonitoringItemModel() { Budgeted = beamContent.Mainbar, Description = "pcs of 6m Mainbar", RunningCost = 0, TotalCost = beamContent.TotalDeliveredMainbar, PropertyName = nameof(RebarworksBeamOutput.Mainbar) },
                            new MonitoringItemModel() { Budgeted = beamContent.ShortBeamLength, Description = "pcs of 6m Bendbars", RunningCost = 0, TotalCost = beamContent.TotalDeliveredShortBeamLength, PropertyName = nameof(RebarworksBeamOutput.ShortBeamLength) },
                            new MonitoringItemModel() { Budgeted = beamContent.Tiewire, Description = "kg/s of (#16) Tiewire", RunningCost = 0, TotalCost = beamContent.TotalDeliveredTiewire, PropertyName = nameof(RebarworksBeamOutput.Tiewire) },
                            new MonitoringItemModel() { Budgeted = beamContent.LateralTies, Description = "pcs of 6m Stirrups", RunningCost = 0, TotalCost = beamContent.TotalDeliveredLateralTies, PropertyName = nameof(RebarworksBeamOutput.LateralTies) }
                         },
                    StorageType = typeof(RebarworksBeamOutput)
                });
            }
        }

        private void LoadFootingContent(Guid monitoringProjectId)
        {
            var footingContent = Context.Set<RebarworksFootingOutput>()
                            .FirstOrDefault(proj => proj.MonitoringProjectId == monitoringProjectId);
            if (footingContent is not null)
            {
                Categories.Add(new MonitoringCategoryModel()
                {
                    Name = "Footing",
                    MonitoringItems = new ObservableCollection<MonitoringItemModel>()
                         {
                            new MonitoringItemModel() { Budgeted = footingContent.Steelbar, Description = "pcs of 6m Mainbar", RunningCost = 0, TotalCost = footingContent.TotalDeliveredSteelbar, PropertyName = nameof(RebarworksFootingOutput.Steelbar) },
                            new MonitoringItemModel() { Budgeted = footingContent.Tiewire, Description = "kg/s of (#16) Tiewire", RunningCost = 0, TotalCost = footingContent.TotalDeliveredTiewire, PropertyName = nameof(RebarworksFootingOutput.Tiewire) },
                         },
                    StorageType = typeof(RebarworksFootingOutput)
                });
            }
        }

        private void LoadSlabContent(Guid monitoringProjectId)
        {
            var slabContent = Context.Set<RebarworksSlabOutput>()
                            .FirstOrDefault(proj => proj.MonitoringProjectId == monitoringProjectId);
            if (slabContent is not null)
            {
                Categories.Add(new MonitoringCategoryModel()
                {
                    Name = "Slab",
                    MonitoringItems = new ObservableCollection<MonitoringItemModel>()
                         {
                            new MonitoringItemModel() { Budgeted = slabContent.Steelbar, Description = "pcs of 6m Steel Bar", RunningCost = 0, TotalCost = slabContent.TotalDeliveredSteelbar, PropertyName = nameof(RebarworksFootingOutput.Steelbar) },
                            new MonitoringItemModel() { Budgeted = slabContent.Tiewire, Description = "kg/s of (#16) Tie wire", RunningCost = 0, TotalCost = slabContent.TotalDeliveredTiewire, PropertyName = nameof(RebarworksFootingOutput.Tiewire) },
                         },
                    StorageType = typeof(RebarworksSlabOutput)
                });
            }
        }

        public override void ExecuteUpdateCommand()
        {
            Update<RebarworksColumnOutput>();
            Update<RebarworksBeamOutput>();
            Update<RebarworksFootingOutput>();
            Update<RebarworksSlabOutput>();
            Context.SaveChanges();
            var projectId = (Guid)Application.Current.Resources["LoadedMonitoringProject"];
            LoadMonitoringProject(projectId);
        }
    }
}