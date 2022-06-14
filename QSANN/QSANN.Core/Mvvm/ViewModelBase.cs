using Microsoft.EntityFrameworkCore;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using QSANN.Core.Events;
using QSANN.Data;
using QSANN.Data.Attributes;
using QSANN.Data.Entities;
using QSANN.Data.Entities.Base;
using System;
using System.Linq;
using System.Reflection;

namespace QSANN.Core.Mvvm
{
    public class ViewModelBase : BindableBase, IDestructible
    {
        private string _String;

        public virtual string Title
        {
            get { return _String; }
            set { SetProperty(ref _String, value); }
        }

        public ViewModelBase()
        {
        }

        public virtual void Destroy()
        {
        }
    }

    public class ViewModelBase<TInputModel, TEntityType> : ViewModelBase
    where TInputModel : BindableBase
    where TEntityType : AuditableProjectEntity, new()
    {
        protected AppDbContext Context { get; }
        protected IEventAggregator EventAggregator { get; }

        public virtual TInputModel InputModel { get; set; }

        public virtual LoadProjectEvent LoadProjectEvent { get; set; }
        public virtual SaveProjectEvent SaveProjectEvent { get; set; }

        private bool _isResultVisible;

        public virtual bool IsResultVisible
        {
            get { return _isResultVisible; }
            set { SetProperty(ref _isResultVisible, value); }
        }

        protected ViewModelBase(AppDbContext context, IEventAggregator eventAggregator)
        {
            Context = context;
            EventAggregator = eventAggregator;
            LoadProjectEvent = EventAggregator.GetEvent<LoadProjectEvent>();
            SaveProjectEvent = EventAggregator.GetEvent<SaveProjectEvent>();

            LoadProjectEvent.Subscribe(LoadProjectInput, ThreadOption.UIThread);
            SaveProjectEvent.Subscribe(SaveProjectInput, ThreadOption.UIThread);
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
                Context.Attach(project).State = EntityState.Modified;
            }
            Context.Attach(projectInDb).State = EntityState.Modified;

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
                        var entityValueAsObject = categoryProject.GetType().GetProperty(propertyInfo.Name).GetValue(categoryProject, null);

                        var actualValue = Convert.ChangeType(entityValueAsObject, propertyInfo.PropertyType);

                        propertyInfo.SetMethod?.Invoke(InputModel, new[] { actualValue });
                    }
                }
            }
        }
    }
}