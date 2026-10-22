using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr7_Sitkov.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewObject.xaml
    /// </summary>
    public partial class NewObject : Page
    {
        public NewObject()
        {
            InitializeComponent();
        }

        private void BackGo (object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
