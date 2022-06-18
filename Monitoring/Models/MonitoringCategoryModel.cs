using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Monitoring.Models
{
    public class MonitoringCategoryModel : BindableBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private ObservableCollection<MonitoringItemModel> _monitoringItems;

        public ObservableCollection<MonitoringItemModel> MonitoringItems
        {
            get { return _monitoringItems; }
            set { SetProperty(ref _monitoringItems, value); }
        }
    }

    public class MonitoringItemModel : BindableBase
    {
        private string _description;

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private decimal _budgeted;

        public decimal Budgeted
        {
            get { return _budgeted; }
            set
            {
                SetProperty(ref _budgeted, value);
                RaisePropertyChanged(nameof(PercentOfCompletion));
            }
        }

        private decimal _runningCost;

        public decimal RunningCost
        {
            get { return _runningCost; }
            set { SetProperty(ref _runningCost, value); }
        }

        private decimal _totalCost;

        public decimal TotalCost
        {
            get { return _totalCost; }
            set
            {
                SetProperty(ref _totalCost, value);
                RaisePropertyChanged(nameof(PercentOfCompletion));
            }
        }

        public decimal PercentOfCompletion
        {
            get
            {
                return (TotalCost / Budgeted) * 100;
            }
        }
    }
}