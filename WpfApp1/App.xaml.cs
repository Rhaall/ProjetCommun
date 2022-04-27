using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.modeles;
using WpfApp1.wrapper;
using WpfApp1.wrappers;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            manageBDD  datas = new manageBDD();
            datas.test();
            WrapChantier test  = new WrapChantier();
            Chantier c1 = new Chantier(2,"579 avenue adolphe alphand","chantier jeffrey","ontestdestrucs");
            Chantier c2 = new Chantier(3,"bezier","chantier florent","ontestdestrucs");
            //test.createChantier(c1);
            //test.createChantier(c1);
            //test.readChantier(2);
            //test.updateChantier(c1);
            
        }
    }
}
