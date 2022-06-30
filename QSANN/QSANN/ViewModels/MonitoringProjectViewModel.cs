using Mapster;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using QSANN.Core.Events;
using QSANN.Core.Mvvm;
using QSANN.Data;
using QSANN.Data.Entities;
using QSANN.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace QSANN.ViewModels
{
    public class MonitoringProjectViewModel : ViewModelBase
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
                LoadProjectCommand.RaiseCanExecuteChanged();
                DeleteProjectCommand.RaiseCanExecuteChanged();
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

        private DelegateCommand _deleteProjectCommand;

        public DelegateCommand DeleteProjectCommand => _deleteProjectCommand ??= new DelegateCommand(async () => await ExecuteDeleteProjectCommandAsync(), () => SelectedProject is not null);

        private async Task ExecuteDeleteProjectCommandAsync()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var project = await _context.Set<MonitoringProject>().FindAsync(SelectedProject.Id);

                _context.Set<MonitoringProject>().Remove(project);

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
                DialogHost.Close("MainMonitoringDialogHost");
            }
        }

        public MonitoringProjectViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, AppDbContext context)
        {
            _eventAggregator = eventAggregator;
            _context = context;
        }

        public async Task ExecuteLoadedCommandAsync()
        {
            var projectsInDb = await _context.Set<MonitoringProject>().OrderBy(project => project.Name).ToListAsync();
            Projects = new ObservableCollection<ProjectItemModel>(projectsInDb.Select(project => project.Adapt<ProjectItemModel>()));
        }

        private Task ExecuteLoadProjectCommandAsync()
        {
            if (Application.Current.Resources.Contains("LoadedMonitoringProject"))
            {
                Application.Current.Resources["LoadedMonitoringProject"] = SelectedProject.Id;
            }
            else
            {
                Application.Current.Resources.Add("LoadedMonitoringProject", SelectedProject.Id);
            }

            _eventAggregator.GetEvent<LoadMonitoringProjectEvent>().Publish(SelectedProject.Id);
            DialogHost.Close("MainMonitoringDialogHost");
            return Task.CompletedTask;
        }
    }
}