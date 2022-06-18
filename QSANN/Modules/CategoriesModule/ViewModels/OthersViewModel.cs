using CategoriesModule.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using QSANN.Core.Navigation;
using QSANN.Data;
using QSANN.Data.Entities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CategoriesModule.ViewModels
{
    [Display(Name = "Other Materials")]
    public class OthersViewModel : MenuItem<OtherMaterialModel, OtherMaterial, OtherMaterialOutput>
    {
        private ObservableCollection<OtherMaterialModel> _otherMaterials;

        public override string Title => "Other Materials";

        public ObservableCollection<OtherMaterialModel> OtherMaterials { get => _otherMaterials; set => SetProperty(ref _otherMaterials, value); }
        public ObservableCollection<string> ConstructionScopes { get; set; }

        private DelegateCommand _addNewItemCommand;
        public DelegateCommand AddNewItemCommand => _addNewItemCommand ??= new DelegateCommand(AddNewItem);

        private DelegateCommand _removeLastItemCommand;

        public DelegateCommand RemoveLastItemCommand => _removeLastItemCommand ??= new DelegateCommand(RemoveLastItem);

        private void RemoveLastItem()
        {
            if (OtherMaterials.Count > 0)
            {
                OtherMaterials.RemoveAt(OtherMaterials.Count - 1);
            }
        }

        public OthersViewModel(IRegionManager regionManager, AppDbContext context, IEventAggregator eventAggregator) : base(regionManager, context, eventAggregator)
        {
            OtherMaterials = new();
            ConstructionScopes = new()
            {
                "Mobilization",
                "Rebar Works",
                "Masonry Works",
                "Plumbing Works",
                "Roofing / Trusses & Metalworks",
                "Electrical Works",
                "Paint Works",
                "Tile Works",
                "Carpentry",
                "Demobilization",
                "Formworks",
                "Fence",
                "Finishing Materials",
                "Consumables",
                "Electrical Devices",
                "Gate and Fence Metal Works",
                "Finishing Materials",
                "Consumables",
                "Electrical Devices",
                "Plumbing Fixtures"
            };
        }

        private void AddNewItem()
        {
            OtherMaterials.Add(new OtherMaterialModel());
        }

        protected override async void LoadProjectInput(Guid projectId)
        {
            await LoadProjectInputAsync(projectId);
        }

        private async Task LoadProjectInputAsync(Guid projectId)
        {
            var otherMaterialsInProject = await Context.Set<OtherMaterial>().Where(other => other.ProjectId == projectId).ToListAsync();

            var otherMaterials = otherMaterialsInProject.ConvertAll(other => other.Adapt<OtherMaterialModel>());

            if (otherMaterialsInProject.Count > 0)
            {
                OtherMaterials.Clear();
                OtherMaterials.AddRange(otherMaterials);
            }
        }

        protected override async void SaveProjectInput(Guid projectId)
        {
            await SaveProjectInputAsync(projectId);
        }

        private async Task SaveProjectInputAsync(Guid projectId)
        {
            if (OtherMaterials.Count > 0)
            {
                var otherMaterialsInProject = await Context.Set<OtherMaterial>().Where(other => other.ProjectId == projectId).ToListAsync();

                Context.Set<OtherMaterial>().RemoveRange(otherMaterialsInProject);

                var currentMaterials = OtherMaterials.Select(other => other.Adapt<OtherMaterial>()).ToList();

                foreach (var currentMaterial in currentMaterials)
                {
                    currentMaterial.ProjectId = projectId;
                }

                Context.Set<OtherMaterial>().AddRange(currentMaterials);

                Context.SaveChanges();
            }
        }
    }
}