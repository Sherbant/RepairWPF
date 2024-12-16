using System;
using System.Collections.ObjectModel;
using RepairWPF.Models;

namespace RepairWPF.ViewModel
{
    public class RequestsViewModel
    {
        public ObservableCollection<Request> Requests { get; set; }

        public ObservableCollection<Status> Statuses { get; set; }

        public string ProblemDescription { get; set; }

        public RelayCommand AddRequestCommand { get; set; }

        public RequestsViewModel()
        {
            Statuses = new ObservableCollection<Status>
            {
                new Status { Id = 1, Name = "Новый" },
                new Status { Id = 2, Name = "В работе" },
                new Status { Id = 3, Name = "Готово" }
            };

            Requests = new ObservableCollection<Request>
            {
                new Request
                {
                    ProblemDescription = "Сломан телевизор",
                    StartDate = DateOnly.FromDateTime(DateTime.Now),
                    StatusId = 1,
                    Status = Statuses[0]
                },
                new Request
                {
                    ProblemDescription = "Не работает холодильник",
                    StartDate = DateOnly.FromDateTime(DateTime.Now),
                    StatusId = 2,
                    Status = Statuses[1]
                }
            };

            AddRequestCommand = new RelayCommand(AddRequest);
        }

        private void AddRequest(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(ProblemDescription))
            {
                Requests.Add(new Request
                {
                    ProblemDescription = ProblemDescription,
                    StartDate = DateOnly.FromDateTime(DateTime.Now),
                    StatusId = 1,
                    Status = Statuses[0]
                });

                ProblemDescription = string.Empty;
            }
        }
    }
}
