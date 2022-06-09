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
using System;
using QSANN.Core.Events;

namespace QSANN.ViewModels
{
    public class LoadProjectDialogViewModel : BindableBase
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
            }
        }

        private ObservableCollection<ProjectItemModel> _projects;

        public ObservableCollection<ProjectItemModel> Projects
        {
            get { return _projects; }
            set { SetProperty(ref _projects, value); }
        }

        private DelegateCommand _loadedCommand;

        public DelegateCommand LoadedCommand => _loadedCommand ??= new DelegateCommand(async () => await ExecuteLoadedCommandAsync());

        private DelegateCommand _loadProjectCommand;

        public DelegateCommand LoadProjectCommand => _loadProjectCommand ??= new DelegateCommand(async () => await ExecuteLoadProjectCommandAsync(),
            () => SelectedProject is not null);

        public LoadProjectDialogViewModel(IEventAggregator eventAggregator, AppDbContext context)
        {
            _eventAggregator = eventAggregator;
            _context = context;
        }

        private async Task ExecuteLoadedCommandAsync()
        {
            var projectsInDb = await _context.Projects.OrderBy(project => project.Name).ToListAsync();

            Projects = new ObservableCollection<ProjectItemModel>(projectsInDb.Select(project => project.Adapt<ProjectItemModel>()));
        }

        private async Task ExecuteLoadProjectCommandAsync()
        {
            _eventAggregator.GetEvent<LoadProjectEvent>().Publish(SelectedProject.Id);
            DialogHost.Close("MainWindowDialogHost");
        }
    }
}