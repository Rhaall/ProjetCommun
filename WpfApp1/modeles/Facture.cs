namespace WpfApp1.modèles
{
    class Facture
    {
        public int _Id;
        public int _TempsEffectif;
        public int _CoutEffectif;
        public string _Commentaire;

        public Facture()
        {
        }

        public Facture(int id, int tempsEffectif, int coutEffectif, string commentaire)
        {
            _Id = id;
            _TempsEffectif = tempsEffectif;
            _CoutEffectif = coutEffectif;
            _Commentaire = commentaire;
        }
    }
}
