using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.modèles;


namespace WpfApp1.modeles
{
    class Chantier
    {
        public int _Id;
        public string _Adresse;
        public string _NomChantier;
        public string _Commentaire;
        public Devis[] _devis;
        public Facture[] _factures;

        public Chantier(int id, string adresse, string nomChantier, string commentaire, Devis[] devis, Facture[] factures)
        {
            _Id = id;
            _Adresse = adresse;
            _NomChantier = nomChantier;
            this._Commentaire = commentaire;
            this._devis = devis;
            this._factures = factures;
        }
        public Chantier(int id, string adresse, string nomChantier, string commentaire)
        {
            _Id = id;
            _Adresse = adresse;
            _NomChantier = nomChantier;
            this._Commentaire = commentaire;
         
        }

        public Chantier()
        {
        }
    }
}