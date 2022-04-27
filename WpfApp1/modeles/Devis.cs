namespace WpfApp1.modeles
{
    class Devis
    {
        public int _Id;
        public int _TempsPrevu;
        public int _CoutPrevu;
        public string _Commentaire;

        public Devis()
        {
        }

        public Devis(int id, int tempsPrevu, int coutPrevu, string commentaire)
        {
            _Id = id;
            _TempsPrevu = tempsPrevu;
            _CoutPrevu = coutPrevu;
            _Commentaire = commentaire;
        }
    }
}
