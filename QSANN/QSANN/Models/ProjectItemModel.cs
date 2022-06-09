using Prism.Mvvm;
using System;

namespace QSANN.Models
{
    public class ProjectItemModel : BindableBase
    {
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private DateTime? _dateCreated;

        public DateTime? DateCreated
        {
            get { return _dateCreated; }
            set { SetProperty(ref _dateCreated, value); }
        }

        private DateTime? _lastUpdated;

        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
            set { SetProperty(ref _lastUpdated, value); }
        }
    }
}