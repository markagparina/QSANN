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
using System.Data.Common;
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
                IEnumerable<IGrouping<string, OtherMaterialOutput>> itemsByScope = ProjectContents.GroupBy(other => other.ConstructionScope);
                
                Categories = new ObservableCollection<MonitoringCategoryModel>(itemsByScope.Select(scope => new MonitoringCategoryModel()
                {
                    Name = scope.Key,
                    MonitoringItems = new ObservableCollection<MonitoringItemModel>(scope.Select(item => new MonitoringItemModel()
                    {
                        Id = item.Id,
                        TotalCost = item.TotalCost,
                        Budgeted = item.Quantity, 
                        Description = $"{item.ItemName} - {item.Description}"
                    })),
                    StorageType = typeof(OtherMaterialOutput)
                }));
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
            foreach (var item in ProjectContents)
            {
                var input = Categories.SelectMany(model => model.MonitoringItems)
                    .FirstOrDefault(inputItem => inputItem.Id == item.Id);

                if (input is not null)
                {
                    item.TotalCost = (input.RunningCost + item.TotalCost) <= item.Quantity
                        ? (input.RunningCost + item.TotalCost)
                        : item.Quantity;
                    Context.Update(item);
                }
            }

            Context.SaveChanges();
        }
    }
}