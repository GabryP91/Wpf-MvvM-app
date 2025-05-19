using System.Windows;
using Wpf_MvvM_app.ViewModel;

namespace Wpf_MvvM_app
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel mv = new MainWindowViewModel();
            DataContext = mv;
        }
    }
}