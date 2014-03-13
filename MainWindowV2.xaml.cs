//Koodannut ja testannut toimivaksi 6.3.2014 Esa Salmikangas.
//Jatkanut Tarleena Marttila 6.3.2014.
//Jatkanut Tarleena Marttila 13.3.2014
using System;
using System.Collections.Generic;
using System.Data;
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
  public partial class MainWindowV2 : Window
  {
    string YhteysMerkkijono;
    string TaulunNimi;
    DataTable dt;
    DataView dv;
    public MainWindowV2()
    {
      InitializeComponent();
      IniMyStuff();
        //muista vaihtaa App.xaml-tiedostossa aloitusikkunaksi tämä ikkuna!
        //StartupUri="MainWindowV2.xaml">

    }

    private void IniMyStuff()
    {
      //esimerkki kuinka App.Configissa oleva connectionstring luetaan
      YhteysMerkkijono = JAMK.ICT.Properties.Settings.Default.Tietokanta;
      lbMessages.Content = YhteysMerkkijono;
      TaulunNimi = JAMK.ICT.Properties.Settings.Default.Taulu;
      //Haetaan datat datatableen ja sen avulla täytetään kaupungit comboboxiin
      try
      {
          string msg = "";
          dt = JAMK.ICT.Data.DBPlacebo.GetAllCustomersFromSQLServer(YhteysMerkkijono, TaulunNimi, out msg);
          dv = dt.DefaultView;
          dgCustomers.ItemsSource = dv;
          //haetaan kaupungit datatablesta
          dv.Sort = "city"; //sortataan dv, jotta saadaan kaupungit järjestykseen
          DataTable dtCities = dv.ToTable("Cities", true, "city"); 
          //("taulunnimi", otetaan vain kerran jokainen, "sarakkeen nimi")
          cbCities.Items.Add("Näytä kaikki");
          foreach (DataRow dr in dtCities.Rows)
          {//laitetaan kaupungit comboboxiin
              cbCities.Items.Add(dr[0].ToString()); 
          }
      }
      catch (Exception ex)
      {

          lbMessages.Content = ex.Message;
      }
    }
    private void cbCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string kaupunki = cbCities.SelectedValue.ToString();
        if (kaupunki == "Näytä kaikki")
        {
            dv.RowFilter = "";
            lbMessages.Content = string.Format("Asiakkaita on {0} yhteensä.", dv.Count);
        }
        else
        {
            dv.RowFilter = string.Format("city LIKE '{0}'", kaupunki);
            lbMessages.Content = string.Format("Valitussa kaupungissa on {0} on {1} asiakasta.", kaupunki, dv.Count);
        }
    }
  }
}
