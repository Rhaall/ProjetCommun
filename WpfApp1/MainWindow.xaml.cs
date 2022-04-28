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
        public MainWindow()
        {
            
            InitializeComponent();
            WrapChantier WC = new WrapChantier();
            chants = WC.getAllChantier();
            //people = GetPeople();
            datagridjeff.ItemsSource = chants;

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
    }
}
