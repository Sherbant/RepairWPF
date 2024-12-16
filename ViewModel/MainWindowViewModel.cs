using RepairWPF.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace RepairWPF.ViewModel
{
    public class MainWindowViewModel
    {
        public ICommand OpenRequestsViewCommand { get; }

        public MainWindowViewModel()
        {
            OpenRequestsViewCommand = new RelayCommand(OpenRequestsView);
        }

        private void OpenRequestsView(object parameter)
        {
            var requestsView = new RequestsView();
            requestsView.Show();
        }
    }
}
