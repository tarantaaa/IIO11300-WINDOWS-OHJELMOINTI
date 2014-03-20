//Koodannut ja testannut toimivaksi 6.3.2014 Esa Salmikangas.
//Jatkanut Tarleena Marttila 6.3.2014.
//Jatkanut Tarleena Marttila 13.3.2014
//Jatkanut Tarleena Marttila 20.3.2014
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
using JAMK.ICT;

namespace H10ADOBlanco
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindowV3 : Window
  {
    //string YhteysMerkkijono;
    //string TaulunNimi;
    //DataTable dt;
    //DataView dv;
    DemoxDataSet ds;
    DataView dv;
    JAMK.ICT.DemoxDataSetTableAdapters.customerTableAdapter myTA;
    public MainWindowV3()
    {
      InitializeComponent();
      IniMyStuff();
        //muista vaihtaa App.xaml-tiedostossa aloitusikkunaksi tämä ikkuna!
        //StartupUri="MainWindowV3.xaml">
    }
    private void IniMyStuff()
    {
        ds = new DemoxDataSet();
        myTA = new JAMK.ICT.DemoxDataSetTableAdapters.customerTableAdapter();
        myTA.Fill(ds.customer);
        dv = ds.customer.DefaultView;
        dgCustomers.DataContext =  ds.customer.DefaultView;
        FillCombo();
    }
    private void FillCombo()
    {
        //täytetään comboboxi LINQn avulla
        var kaupungit = (from k in ds.customer 
                        where k.City != null
                        select k.City).Distinct();
        cbCities.Items.Add("Kaikki");
        foreach (var k in kaupungit)
        {
            cbCities.Items.Add(k);
        }
    }
    private void cbCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string kaupunki = cbCities.SelectedValue.ToString();
        if (kaupunki == "Kaikki")
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

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        //tallenetaan muutokset kantaan
        try
        {

            myTA.Update(ds);
            myTA.Fill(ds.customer);
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }
    }
  }
}
