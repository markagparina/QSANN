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
    [Display(Name = "Concrete")]
    public class ConcreteMonitoringViewModel : MonitoringMenuItemBase
    {
        private DelegateCommand _updateCommand;
        public DelegateCommand UpdateCommand => _updateCommand ??= new DelegateCommand(ExecuteUpdateCommand);

        public ConcreteMonitoringViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, AppDbContext context) : base(regionManager, context, eventAggregator)
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
            var columnContent = Context.Set<ConcreteColumnOutput>()
                .FirstOrDefault(proj => proj.MonitoringProjectId == monitoringProjectId);
            if (columnContent is not null)
            {
                Categories.Add(new MonitoringCategoryModel()
                {
                    Name = "Column",
                    MonitoringItems = new ObservableCollection<MonitoringItemModel>()
                         {
                            new MonitoringItemModel() { Budgeted = columnContent.CementMixture, Description = "Bags of Cement", RunningCost = 0, TotalCost = columnContent.TotalDeliveredCementMixture, PropertyName = nameof(ConcreteColumnOutput.CementMixture) },
                            new MonitoringItemModel() { Budgeted = columnContent.Sand, Description = "m\xB3 of Sand", RunningCost = 0, TotalCost = columnContent.TotalDeliveredSand, PropertyName = nameof(ConcreteColumnOutput.Sand) },
                            new MonitoringItemModel() { Budgeted = columnContent.Gravel, Description = "m\xB3 (3/4\") of Gravel", RunningCost = 0, TotalCost = columnContent.TotalDeliveredGravel, PropertyName = nameof(ConcreteColumnOutput.Gravel) }
                         },
                    StorageType = typeof(ConcreteColumnOutput)
                });
            }
        }

        private void LoadBeamContent(Guid monitoringProjectId)
        {
            var beamContent = Context.Set<ConcreteBeamOutput>()
                .FirstOrDefault(proj => proj.MonitoringProjectId == monitoringProjectId);
            if (beamContent is not null)
            {
                Categories.Add(new MonitoringCategoryModel()
                {
                    Name = "Beam",
                    MonitoringItems = new ObservableCollection<MonitoringItemModel>()
                         {
                             new MonitoringItemModel() { Budgeted = beamContent.CementMixture, Description = "Bags of Cement", RunningCost = 0, TotalCost = beamContent.TotalDeliveredCementMixture, PropertyName = nameof(ConcreteBeamOutput.CementMixture) },
                             new MonitoringItemModel() { Budgeted = beamContent.Sand, Description = "m\xB3 of Sand", RunningCost = 0, TotalCost = beamContent.TotalDeliveredSand, PropertyName = nameof(ConcreteBeamOutput.Sand) },
                             new MonitoringItemModel() { Budgeted = beamContent.Gravel, Description = "m\xB3 (3/4\") of Gravel", RunningCost = 0, TotalCost = beamContent.TotalDeliveredGravel, PropertyName = nameof(ConcreteBeamOutput.Gravel) }
                         },
                    StorageType = typeof(ConcreteBeamOutput)
                });
            }
        }

        private void LoadSlabContent(Guid monitoringProjectId)
        {
            var slabContent = Context.Set<ConcreteSlabOutput>()
                .FirstOrDefault(proj => proj.MonitoringProjectId == monitoringProjectId);
            if (slabContent is not null)
            {
                Categories.Add(new MonitoringCategoryModel()
                {
                    Name = "Slab",
                    MonitoringItems = new ObservableCollection<MonitoringItemModel>()
                    {
                        new MonitoringItemModel() { Budgeted = slabContent.CementMixture, Description = "Bags of Cement", RunningCost = 0, TotalCost = slabContent.TotalDeliveredCementMixture, PropertyName = nameof(ConcreteSlabOutput.CementMixture) },
                        new MonitoringItemModel() { Budgeted = slabContent.Sand, Description = "m\xB3 of Sand", RunningCost = 0, TotalCost = slabContent.TotalDeliveredSand, PropertyName = nameof(ConcreteSlabOutput.Sand) },
                        new MonitoringItemModel() { Budgeted = slabContent.Gravel, Description = "m\xB3 (3/4\") of Gravel", RunningCost = 0, TotalCost = slabContent.TotalDeliveredGravel, PropertyName = nameof(ConcreteSlabOutput.Gravel) }
                    },
                    StorageType = typeof(ConcreteSlabOutput)
                });
            }
        }

        private void LoadFootingContent(Guid monitoringProjectId)
        {
            var footingContent = Context.Set<ConcreteFootingOutput>()
                            .FirstOrDefault(proj => proj.MonitoringProjectId == monitoringProjectId);
            if (footingContent is not null)
            {
                Categories.Add(new MonitoringCategoryModel()
                {
                    Name = "Footing",
                    MonitoringItems = new ObservableCollection<MonitoringItemModel>()
                         {
                             new MonitoringItemModel() { Budgeted = footingContent.CementMixture, Description = "Bags of Cement", RunningCost = 0, TotalCost = footingContent.TotalDeliveredCementMixture, PropertyName = nameof(ConcreteFootingOutput.CementMixture) },
                             new MonitoringItemModel() { Budgeted = footingContent.Sand, Description = "m\xB3 of Sand", RunningCost = 0, TotalCost = footingContent.TotalDeliveredSand, PropertyName = nameof(ConcreteFootingOutput.Sand) },
                             new MonitoringItemModel() { Budgeted = footingContent.Gravel, Description = "m\xB3 (3/4\") of Gravel", RunningCost = 0, TotalCost = footingContent.TotalDeliveredGravel, PropertyName = nameof(ConcreteFootingOutput.Gravel) }
                         },
                    StorageType = typeof(ConcreteFootingOutput)
                });
            }
        }

        public override void ExecuteUpdateCommand()
        {
            Update<ConcreteColumnOutput>();
            Update<ConcreteBeamOutput>();
            Update<ConcreteSlabOutput>();
            Update<ConcreteFootingOutput>();
            Context.SaveChanges();
            var projectId = (Guid)Application.Current.Resources["LoadedMonitoringProject"];
            LoadMonitoringProject(projectId);
        }
    }
}