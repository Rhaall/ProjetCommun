using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.modèles;


namespace WpfApp1.modeles
{
    class Chantier
    {
        public int Id;
        public string Adresse;
        public string NomChantier;
        public string commentaire;
        public Devis[] devis;
        public Facture[] factures;

        public Chantier(int id, string adresse, string nomChantier, string commentaire, Devis[] devis, Facture[] factures)
        {
            Id = id;
            Adresse = adresse;
            NomChantier = nomChantier;
            this.commentaire = commentaire;
            this.devis = devis;
            this.factures = factures;
        }

        
    }
}