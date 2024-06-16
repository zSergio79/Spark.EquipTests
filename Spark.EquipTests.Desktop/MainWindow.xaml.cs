using Spark.EquipTests.Desktop.Models;
using Spark.EquipTests.Desktop.ViewModels;

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

namespace Spark.EquipTests.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Задать контекст
            //TODO можно было бы использовать IOC Container для регистрации и разрешения зависимостей
            DataContext = new MainViewModel(new EquipTestDbData(), new ParametersTestDbData());
        }
    }
}