using RepairWPF.View;
using RepairWPF.ViewModel;
using System.Windows;

namespace RepairWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
