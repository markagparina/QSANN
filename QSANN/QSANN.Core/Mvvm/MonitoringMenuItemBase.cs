using Prism.Events;
using Prism.Regions;
using QSANN.Core.Events;
using QSANN.Core.Models;
using QSANN.Core.Navigation;
using QSANN.Data;
using QSANN.Data.Entities;
using QSANN.Data.Entities.Base;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;

namespace QSANN.Core.Mvvm
{
    public abstract class MonitoringMenuItemBase : MenuItem
    {
        protected AppDbContext Context { get; }
        protected IEventAggregator EventAggregator { get; }

        private ObservableCollection<MonitoringCategoryModel> _categories;

        public ObservableCollection<MonitoringCategoryModel> Categories
        {
            get { return _categories; }
            set
            {
                SetProperty(ref _categories, value);
                RaisePropertyChanged(nameof(CanUpdate));
            }
        }

        public bool CanUpdate => Categories?.Count > 0;

        public MonitoringMenuItemBase(IRegionManager regionManager, AppDbContext context, IEventAggregator eventAggregator) : base(regionManager)
        {
            Context = context;
            EventAggregator = eventAggregator;
            EventAggregator.GetEvent<LoadMonitoringProjectEvent>().Subscribe(LoadMonitoringProject);
            Categories = new ObservableCollection<MonitoringCategoryModel>();
            Categories.CollectionChanged +=CategoriesOnCollectionChanged; 
        }

        private void CategoriesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(CanUpdate));
        }

        public virtual void LoadMonitoringProject(Guid monitoringProjectId)
        {
        }

        public abstract void ExecuteUpdateCommand();

        public virtual void Update<TEntity>() where TEntity : AuditableMonitoringProjectEntity
        {
            var projectId = (Guid)Application.Current.Resources["LoadedMonitoringProject"];
            var carpentryProject = Context.Set<TEntity>().FirstOrDefault(proj => proj.MonitoringProjectId == projectId);

            foreach (var monitoringItem in Categories.Where(category => category.StorageType == typeof(TEntity)).SelectMany(category => category.MonitoringItems))
            {
                var propertyToUpdate = carpentryProject.GetType().GetProperty("TotalDelivered" + monitoringItem.PropertyName);

                if (propertyToUpdate is not null)
                {
                    var currentValue = (decimal)Convert.ChangeType(propertyToUpdate.GetValue(carpentryProject), propertyToUpdate.PropertyType);

                    decimal value = (currentValue + monitoringItem.RunningCost) <= monitoringItem.Budgeted
                    ? (currentValue + monitoringItem.RunningCost)
                    : monitoringItem.Budgeted;

                    propertyToUpdate.SetValue(carpentryProject, value, null);
                }
            }
        }
    }
}