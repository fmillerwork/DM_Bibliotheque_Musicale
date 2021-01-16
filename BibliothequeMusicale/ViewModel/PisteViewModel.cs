namespace BibliothequeMusicale
{
    class PisteViewModel : Observable
    {
        private readonly Piste _model;

        public PisteViewModel()
        {
            _model = new Piste();
        }

        public PisteViewModel(Piste model)
        {
            _model = model;
        }

        public int ID
        {
            get => _model.ID;
            set { _model.ID = value; OnPropertyChanged(nameof(ID)); OnPropertyChanged(nameof(IDNom)); }
        }

        public string Nom
        {
            get => _model.Nom;
            set { _model.Nom = value; OnPropertyChanged(nameof(Nom)); OnPropertyChanged(nameof(IDNom)); }
        }
        public string IDNom
        {
            get => $"{_model.ID} - {_model.Nom}";
        }
    }
}
