using RepairWPF.ViewModel;
using System.Windows;

namespace RepairWPF.View
{
    public partial class RequestsView : Window
    {
        public RequestsView()
        {
            InitializeComponent();
            DataContext = new RequestsViewModel();
        }
    }
}
