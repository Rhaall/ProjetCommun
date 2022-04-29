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
using WpfApp1.modeles;
using WpfApp1.modèles;
using WpfApp1.tests;
using WpfApp1.wrappers;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Chantier> chants = new List<Chantier>();
        List<person> people = new List<person>();
        List<Facture> factures = new List<Facture>();
        List<Devis> devis = new List<Devis>();
        List<Compagnon> compagnons = new List<Compagnon>();
        public MainWindow()
        {
            
            InitializeComponent();
            WrapChantier WC = new WrapChantier();
            chants = WC.getAllChantier();
            //people = GetPeople();
            WrapFacture WCF = new WrapFacture();
            factures = WCF.getAllFacture();
            dataChantier.ItemsSource = chants;
            datafacture.ItemsSource = factures;
            WrapDevis WDD  = new WrapDevis();
            devis = WDD.getAllDevis();
            datadevis.ItemsSource = devis;
            WrapCompagnon wrapCompagnon = new WrapCompagnon();
            compagnons = wrapCompagnon.getAllCompagnon();
            dataCompagnon.ItemsSource = compagnons;

        }

        private List<person> GetPeople()
        {
            
            List<person> people = new List<person>();
            people.Add(new person() { PersonId=1 ,Name="jeffrey",Surname="fevre",Profession="dev" });
            people.Add(new person() { PersonId=2 ,Name="flo",Surname="chav",Profession="dev" });
            people.Add(new person() { PersonId=3 ,Name="arnal",Surname="florez",Profession="dev" });
            return people;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("coucou");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void datagridjeff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void searchChantier_Click(object sender, RoutedEventArgs e)
        {
            
            Dictionary<string, string> dicChantier = new Dictionary<string, string>();
            dicChantier.Add("id_chantier", id_chantier.Text);
            dicChantier.Add("nom_chantier", nom_chantier.Text);
            dicChantier.Add("adresse", adresse_chantier.Text);
            dicChantier.Add("chantier_com", chantier_com.Text);
            WrapChantier WC = new WrapChantier();
            List<Chantier> lch=  WC.searchChantierMultiParam(dicChantier);
            dataChantier.ItemsSource = lch;
        }
    }
}
