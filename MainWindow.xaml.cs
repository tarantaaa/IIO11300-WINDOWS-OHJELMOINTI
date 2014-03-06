//Koodannut ja testannut toimivaksi 6.3.2014 Esa Salmikangas.
//Jatkanut Tarleena Marttila 6.3.2014.
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

namespace H10ADOBlanco
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      IniMyStuff();
    }

    private void IniMyStuff()
    {
      //TODO täytetään combobox asiakkaitten maitten nimillä
      //esimerkki kuinka App.Configissa oleva connectionstring luetaan
      lbMessages.Content = JAMK.ICT.Properties.Settings.Default.Tietokanta;
    }

    private void btnGet3_Click(object sender, RoutedEventArgs e)
    {
      //TODO
    }

    private void btnGetAll_Click(object sender, RoutedEventArgs e)
    {
      //TODO
    }

    private void btnGetFrom_Click(object sender, RoutedEventArgs e)
    {
      //TODO
    }
  }
}
