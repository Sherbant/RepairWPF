using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RepairWPF.View;

namespace RepairWPF.ViewModel
{
    public class MainWindowViewModel
    {
        public ICommand OpenRequestsViewCommand { get; set; }

        public MainWindowViewModel()
        {
            OpenRequestsViewCommand = new RelayCommand(OpenRequestsView);
        }

        private void OpenRequestsView()
        {
            var requestPage = new View.RequestsView();
            var frame = Application.Current.MainWindow.FindName("MainFrame") as Frame;
            frame?.Navigate(requestPage);
        }
    }

}
