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
    [Display(Name = "Formworks")]
    public class FormworksMonitoringViewModel : MonitoringMenuItemBase
    {
        private DelegateCommand _updateCommand;
        public DelegateCommand UpdateCommand => _updateCommand ??= new DelegateCommand(ExecuteUpdateCommand);

        public FormworksMonitoringViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, AppDbContext context) : base(regionManager, context, eventAggregator)
        {
        }

        public override void LoadMonitoringProject(Guid monitoringProjectId)
        {
            var columnContent = Context.Set<FormworksColumnOutput>()
                            .FirstOrDefault(proj => proj.MonitoringProjectId == monitoringProjectId);

            var beamContent = Context.Set<FormworksBeamOutput>()
                            .FirstOrDefault(proj => proj.MonitoringProjectId == monitoringProjectId);

            Categories.Clear();
            if (columnContent is not null)
            {
                Categories.Add(new MonitoringCategoryModel()
                {
                    Name = "Column",
                    MonitoringItems = new ObservableCollection<MonitoringItemModel>()
                         {
                            new MonitoringItemModel() { Budgeted = columnContent.NumberOfPlywood, Description = "pcs of 4'x8' Plywood", RunningCost = 0, TotalCost = columnContent.TotalDeliveredNumberOfPlywood, PropertyName = nameof(FormworksColumnOutput.NumberOfPlywood) },
                            new MonitoringItemModel() { Budgeted = columnContent.NumberOfBoardFeetLumber, Description = "Bd.ft Lumber", RunningCost = 0, TotalCost = columnContent.TotalDeliveredNumberOfBoardFeetLumber, PropertyName = nameof(FormworksColumnOutput.NumberOfBoardFeetLumber) }
                         },
                    StorageType = typeof(FormworksColumnOutput)
                });
            }

            if (beamContent is not null)
            {
                Categories.Add(new MonitoringCategoryModel()
                {
                    Name = "Beam",
                    MonitoringItems = new ObservableCollection<MonitoringItemModel>()
                         {
                            new MonitoringItemModel() { Budgeted = beamContent.NumberOfPlywood, Description = "pcs of 4'x8' Plywood", RunningCost = 0, TotalCost = beamContent.TotalDeliveredNumberOfPlywood, PropertyName = nameof(FormworksBeamOutput.NumberOfPlywood) },
                            new MonitoringItemModel() { Budgeted = beamContent.NumberOfBoardFeetLumber, Description = "Bd.ft Lumber", RunningCost = 0, TotalCost = beamContent.TotalDeliveredNumberOfBoardFeetLumber, PropertyName = nameof(FormworksBeamOutput.NumberOfBoardFeetLumber) },
                         },
                    StorageType = typeof(FormworksBeamOutput)
                });
            }
        }

        public override void ExecuteUpdateCommand()
        {
            Update<FormworksColumnOutput>();
            Update<FormworksBeamOutput>();
            Context.SaveChanges();
            var projectId = (Guid)Application.Current.Resources["LoadedMonitoringProject"];
            LoadMonitoringProject(projectId);
        }
    }
}