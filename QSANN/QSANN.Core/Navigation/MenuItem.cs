using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using QSANN.Core.Events;
using QSANN.Core.Mvvm;
using QSANN.Data;
using QSANN.Data.Attributes;
using QSANN.Data.Entities.Base;
using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using QSANN.Data.Entities;
using FluentValidation;
using QSANN.Core.Commands;

namespace QSANN.Core.Navigation
{
    public class MenuItem : RegionViewModelBase, IMenuItem
    {
        public MenuItem(IRegionManager regionManager) : base(regionManager)
        {
        }
    }

    public class MenuItem<TInputModel, TEntityType, TOutputStorage, TValidator> : MenuItem
            where TInputModel : BindableBase
            where TEntityType : AuditableProjectEntity, new()
            where TOutputStorage : AuditableMonitoringProjectEntity
            where TValidator : AbstractValidator<TInputModel>
    {
        protected AppDbContext Context { get; }
        protected IEventAggregator EventAggregator { get; }
        public virtual TInputModel InputModel { get; set; }
        public virtual TOutputStorage OutputStorage { get; set; }

        public virtual DelegateCommandWithValidator<TInputModel, TValidator> CalculateCommand { get; set; }

        private bool _isResultVisible;

        public virtual bool IsResultVisible
        {
            get { return _isResultVisible; }
            set { SetProperty(ref _isResultVisible, value); }
        }

        public virtual LoadProjectEvent LoadProjectEvent { get; set; }
        public virtual SaveProjectEvent SaveProjectEvent { get; set; }
        public virtual SaveMonitoringProjectEvent SaveMonitoringProjectEvent { get; set; }

        protected MenuItem(IRegionManager regionManager, AppDbContext context, IEventAggregator eventAggregator) : base(regionManager)
        {
            Context = context;
            EventAggregator = eventAggregator;

            LoadProjectEvent = EventAggregator.GetEvent<LoadProjectEvent>();
            SaveProjectEvent = EventAggregator.GetEvent<SaveProjectEvent>();
            SaveMonitoringProjectEvent = EventAggregator.GetEvent<SaveMonitoringProjectEvent>();

            LoadProjectEvent.Unsubscribe(LoadProjectInput);
            LoadProjectEvent.Subscribe(LoadProjectInput, ThreadOption.UIThread);

            SaveProjectEvent.Unsubscribe(SaveProjectInput);
            SaveProjectEvent.Subscribe(SaveProjectInput, ThreadOption.UIThread);

            SaveMonitoringProjectEvent.Unsubscribe(SaveProjectOutput);
            SaveMonitoringProjectEvent.Subscribe(SaveProjectOutput, ThreadOption.UIThread);

            EventAggregator.GetEvent<CalculateAllCategoriesEvent>().Subscribe(() => CalculateCommand.Execute());
        }



        protected virtual void SaveProjectOutput(Guid monitoringProjectId)
        {
            OutputStorage.MonitoringProjectId = monitoringProjectId;
            OutputStorage.Id = Guid.NewGuid();
            Context.Set<TOutputStorage>().Add(OutputStorage);
            Context.SaveChanges();
        }

        protected virtual void SaveProjectInput(Guid projectId)
        {
            var categoryProject = Context.Set<TEntityType>().FirstOrDefault(category => category.ProjectId == projectId);
            var projectInDb = Context.Set<Project>().FirstOrDefault(proj => proj.Id == projectId);

            bool saveMode = categoryProject is null;
            TEntityType project = categoryProject ?? new TEntityType();

            var modelProperties = project.GetType().GetProperties().Where(prop => prop.CanWrite && prop.MemberType == MemberTypes.Property && prop.GetCustomAttribute<MappingIgnoredAttribute>() is null);

            foreach (var propertyInfo in modelProperties)
            {
                if (propertyInfo?.CanWrite == true)
                {
                    var existingProperty = InputModel.GetType().GetProperty(propertyInfo.Name);

                    if (propertyInfo.Name == nameof(AuditableProjectEntity.ProjectId))
                    {
                        propertyInfo.SetValue(project, projectInDb?.Id);
                    }
                    else if (existingProperty != null)
                    {
                        var entityValueAsObject = existingProperty.GetValue(InputModel, null);

                        var actualValue = Convert.ChangeType(entityValueAsObject, propertyInfo.PropertyType);

                        propertyInfo.SetValue(project, actualValue, null);
                    }
                }
            }

            if (saveMode)
            {
                Context.Set<TEntityType>().Add(project);
            }
            else
            {
                Context.Set<TEntityType>().Update(project);
            }
            Context.Set<Project>().Update(projectInDb);

            Context.SaveChanges();
        }

        protected virtual void LoadProjectInput(Guid projectId)
        {
            var categoryProject = Context.Set<TEntityType>().AsNoTracking().FirstOrDefault(category => category.ProjectId == projectId);

            if (categoryProject is not null)
            {
                var modelProperties = InputModel.GetType().GetProperties().Where(prop => prop.CanWrite && prop.MemberType == MemberTypes.Property);

                foreach (var propertyInfo in modelProperties)
                {
                    if (propertyInfo != null && propertyInfo.CanWrite)
                    {
                        var entityValueAsObject = categoryProject.GetType().GetProperty(propertyInfo.Name)?.GetValue(categoryProject, null);

                        object actualValue = null;

                        if (propertyInfo.PropertyType.IsEnum)
                        {
                            var enumType = Enum.GetUnderlyingType(propertyInfo.PropertyType);

                            actualValue = Convert.ChangeType(entityValueAsObject, enumType);
                        }
                        else
                        {
                            actualValue = Convert.ChangeType(entityValueAsObject, propertyInfo.PropertyType);
                        }

                        if (actualValue != null)
                        {
                            propertyInfo.SetMethod?.Invoke(InputModel, new[] { actualValue });
                        }
                    }
                }
            }

            IsResultVisible = false;
        }
    }
}