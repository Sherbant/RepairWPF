using RepairWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RepairWPF.ViewModel
{
    public class RequestViewModel : INotifyPropertyChanged
    {
        private string _problemDescription;
        private ObservableCollection<Request> _requests;

        public string ProblemDescription
        {
            get => _problemDescription;
            set
            {
                _problemDescription = value;
                OnPropertyChanged(nameof(ProblemDescription));
            }
        }

        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set
            {
                _requests = value;
                OnPropertyChanged(nameof(Requests));
            }
        }

        public ICommand AddRequestCommand { get; }

        public RequestViewModel()
        {
            Requests = new ObservableCollection<Request>();
            AddRequestCommand = new RelayCommand(AddRequest); 
        }

        private void AddRequest()
        {
            var newRequest = new Request
            {
                ProblemDescription = ProblemDescription,
                StartDate = DateOnly.FromDateTime(DateTime.Now), 
                StatusId = 1
            };

            Requests.Add(newRequest);
            ProblemDescription = string.Empty;
        }

        private void LoadRequests()
        {
            using (var context = new RepairDbContext())
            {
                var requests = context.Requests.ToList();
                Requests = new ObservableCollection<Request>(requests);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
