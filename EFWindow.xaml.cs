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
using System.Windows.Shapes;

namespace JAMK.ICT
{
    /// <summary>
    /// Interaction logic for EFWindow.xaml
    /// </summary>
    public partial class EFWindow : Window
    {
        public EFWindow()
        {
            InitializeComponent();
        }

        private void cbCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void btnShowGB_Click(object sender, RoutedEventArgs e)
        {
            if (gbUusi.Visibility == Visibility.Collapsed)
            {
                gbUusi.Visibility = Visibility.Visible;
            }
            else
                gbUusi.Visibility = Visibility.Collapsed;
        }

        private void btnLuoUusi_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
