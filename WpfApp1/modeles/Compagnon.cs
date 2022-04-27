using System;

namespace WpfApp1.modèles
{
    class Compagnon
    {
        public int _Id;
        public string _Name;
        public string _Telephone;
        public int _CoutHoraire;
        public string _DateEmbauche;
        public string _Commentaire;

        public Compagnon()
        {
        }

        public Compagnon(int id, string name, string telephone, int coutHoraire, DateTime dateEmbauche, string commentaire)
        {
            _Id = id;
            _Name = name;
            _Telephone = telephone;
            _CoutHoraire = coutHoraire;
            _DateEmbauche = dateEmbauche;
            _Commentaire = commentaire;
        }
    }
}
