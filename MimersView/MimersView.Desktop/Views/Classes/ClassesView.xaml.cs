using MimersView.Desktop.ViewModels;
using System.Windows.Controls;

namespace MimersView.Desktop.Views
{
    public partial class ClassesView : UserControl
    {
        public ClassesView()
        {
            InitializeComponent();
            DataContext = new ClassesViewVM(); // Bind ViewModel
        }
    }
}