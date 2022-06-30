using Prism.Mvvm;
using QSANN.Data;
using QSANN.Models;
using System.Collections.ObjectModel;
using Prism.Commands;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Mapster;
using Prism.Events;
using MaterialDesignThemes.Wpf;
using QSANN.Core.Events;
using QSANN.Data.Entities;
using QSANN.Core.Mvvm;
using Prism.Regions;
using QSANN.Core;
using System;

namespace QSANN.ViewModels
{
    public class ProjectDialogViewModel : RegionViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly AppDbContext _context;

        private ProjectItemModel _selectedProject;

        public ProjectItemModel SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                SetProperty(ref _selectedProject, value);
                ProjectName = SelectedProject?.Name ?? string.Empty;
                LoadProjectCommand.RaiseCanExecuteChanged();
                OverwriteSelectedProjectCommand.RaiseCanExecuteChanged();
                SaveNewProjectCommand.RaiseCanExecuteChanged();
                DeleteProjectCommand.RaiseCanExecuteChanged();
            }
        }

        private string _projectName;

        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                SetProperty(ref _projectName, value);
                SaveNewProjectCommand.RaiseCanExecuteChanged();
                SaveNewMonitoringProjectCommand.RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<ProjectItemModel> _projects;

        public ObservableCollection<ProjectItemModel> Projects
        {
            get { return _projects; }
            set { SetProperty(ref _projects, value); }
        }

        private DelegateCommand _loadProjectCommand;

        public DelegateCommand LoadProjectCommand => _loadProjectCommand ??= new DelegateCommand(async () => await ExecuteLoadProjectCommandAsync(),
            () => SelectedProject is not null);

        private DelegateCommand _overwriteSelectedProjectCommand;

        public DelegateCommand OverwriteSelectedProjectCommand => _overwriteSelectedProjectCommand ??= new DelegateCommand(async () => await ExecuteOverwriteProjectCommandAsync(),
            () => SelectedProject is not null && !string.IsNullOrEmpty(SelectedProject.Name));

        private DelegateCommand _saveNewProjectCommand;

        public DelegateCommand SaveNewProjectCommand => _saveNewProjectCommand ??= new DelegateCommand(async () => await ExecuteSaveNewProjectCommandAsync(),
            () => !string.IsNullOrEmpty(ProjectName));

        private DelegateCommand _saveNewMonitoringProjectCommand;

        public DelegateCommand SaveNewMonitoringProjectCommand => _saveNewMonitoringProjectCommand ??= new DelegateCommand(async () => await ExecuteSaveNewMonitoringProjectCommandAsync(),
            () => !string.IsNullOrEmpty(ProjectName));

        private DelegateCommand _deleteProjectCommand;

        public DelegateCommand DeleteProjectCommand => _deleteProjectCommand ??= new DelegateCommand(async () => await ExecuteDeleteProjectCommandAsync(), () => SelectedProject is not null);

        private async Task ExecuteDeleteProjectCommandAsync()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var project = await _context.Set<Project>().FindAsync(SelectedProject.Id);

                _context.Set<Project>().Remove(project);

                _context.SaveChanges();

                await ExecuteLoadedCommandAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }
            finally
            {
                DialogHost.Close("MainWindowDialogHost");
            }
        }

        private async Task ExecuteSaveNewMonitoringProjectCommandAsync()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var project = new MonitoringProject() { Name = ProjectName };

                _context.Set<MonitoringProject>().Add(project);

                _context.SaveChanges();

                _eventAggregator.GetEvent<SaveMonitoringProjectEvent>().Publish(project.Id);

                await ExecuteLoadedCommandAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }
            finally
            {
                DialogHost.Close("MainWindowDialogHost");
            }
        }

        public ProjectDialogViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, AppDbContext context) : base(regionManager)
        {
            _eventAggregator = eventAggregator;
            _context = context;
        }

        public async Task ExecuteLoadedCommandAsync()
        {
            var projectsInDb = await _context.Set<Project>().OrderBy(project => project.Name).ToListAsync();
            Projects = new ObservableCollection<ProjectItemModel>(projectsInDb.Select(project => project.Adapt<ProjectItemModel>()));
        }

        private Task ExecuteLoadProjectCommandAsync()
        {
            _eventAggregator.GetEvent<LoadProjectEvent>().Publish(SelectedProject.Id);
            DialogHost.Close("MainWindowDialogHost");
            return Task.CompletedTask;
        }

        private async Task ExecuteOverwriteProjectCommandAsync()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var existingProject = _context.Set<Project>().FirstOrDefault(project => project.Id == SelectedProject.Id);

                if (existingProject is not null)
                {
                    existingProject.Name = ProjectName;
                    _eventAggregator.GetEvent<SaveProjectEvent>().Publish(existingProject.Id);
                }

                await ExecuteLoadedCommandAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }
            finally
            {
                DialogHost.Close("MainWindowDialogHost");
            }
        }

        private async Task ExecuteSaveNewProjectCommandAsync()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var project = new Project() { Name = ProjectName };

                _context.Set<Project>().Add(project);

                _context.SaveChanges();

                _eventAggregator.GetEvent<SaveProjectEvent>().Publish(project.Id);

                await ExecuteLoadedCommandAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }
            finally
            {
                DialogHost.Close("MainWindowDialogHost");
            }
        }
    }
}