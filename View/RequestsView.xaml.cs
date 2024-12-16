using RepairWPF.View;
using RepairWPF.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RepairWPF.View
{
    /// <summary>
    /// Логика взаимодействия для RequestsView.xaml
    /// </summary>
    public partial class RequestsView : Window
    {
        public RequestsView()
        {
            InitializeComponent();
            DataContext = new RequestViewModel();
        }
    }
    }
