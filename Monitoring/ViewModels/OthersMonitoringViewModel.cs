using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using QSANN.Core.Models;
using QSANN.Core.Mvvm;
using QSANN.Data;
using QSANN.Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;

namespace Monitoring.ViewModels
{
    [Display(Name = "Others")]
    public class OthersMonitoringViewModel : MonitoringMenuItemBase
    {
        private DelegateCommand _updateCommand;

        private List<OtherMaterialOutput> ProjectContents { get; set; }

        public OthersMonitoringViewModel(IRegionManager regionManager, IEventAggregator eventAggregator,
            AppDbContext context) : base(regionManager, context, eventAggregator)
        {
        }

        public DelegateCommand UpdateCommand => _updateCommand ??= new DelegateCommand(ExecuteUpdateCommand);

        public override void LoadMonitoringProject(Guid monitoringProjectId)
        {
            ProjectContents = Context.Set<OtherMaterialOutput>()
                .Where(proj => proj.MonitoringProjectId == monitoringProjectId).ToList();

            if (ProjectContents.Any())
            {
                Categories = new ObservableCollection<MonitoringCategoryModel>
                {
                    new MonitoringCategoryModel
                    {
                        Name = "",
                        MonitoringItems = new ObservableCollection<MonitoringItemModel>(
                            ProjectContents.Select(other => new MonitoringItemModel
                            {
                                Id = other.Id,
                                TotalCost = other.TotalCost,
                                Budgeted = other.Quantity, 
                                Description = $"{other.ItemName} - {other.Description}"
                            })),
                        StorageType = typeof(OtherMaterialOutput)
                    }
                };
            }
        }

        public override void ExecuteUpdateCommand()
        {
            Update<OtherMaterialOutput>();
            Guid projectId = (Guid)Application.Current.Resources["LoadedMonitoringProject"];
            LoadMonitoringProject(projectId);
        }

        public override void Update<TEntity>()
        {
            
        }
    }
}