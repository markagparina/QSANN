using CategoriesModule;
using CategoriesModule.Dialogs;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism.Unity;
using QSANN.Core;
using QSANN.Core.Mvvm;
using QSANN.Core.Navigation;
using QSANN.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QSANN.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;
        private string _title = "QSANN";

        public override string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, string.IsNullOrEmpty(value) ? "QSANN" : value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }


    }
}