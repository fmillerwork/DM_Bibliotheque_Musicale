using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BibliothequeMusicale
{
    class AlbumViewModel : Observable
    {
        #region [ Champs ]

        private readonly Album _model;
        public ObservableCollection<PisteViewModel> Pistes { get; }

        private PisteViewModel _selectedPiste;
        public PisteViewModel SelectedPiste
        {
            get => _selectedPiste;
            set => SetProperty(ref _selectedPiste, value);
        }
        public string Compositeur
        {
            get => _model.Compositeur;
            set { _model.Compositeur = value; OnPropertyChanged(nameof(Compositeur)); }
        }

        public string Titre
        {
            get => _model.Titre;
            set { _model.Titre = value; OnPropertyChanged(nameof(Titre)); }
        }
        #endregion

        #region [ Constructeurs ]
        public AlbumViewModel()
        {
            Pistes = new ObservableCollection<PisteViewModel>();
            _model = new Album();
        }

        public AlbumViewModel(Album model)
        {
            Pistes = new ObservableCollection<PisteViewModel>();
            _model = model;
            foreach (Piste piste in model.Pistes)
            {
                Pistes.Add(new PisteViewModel(piste));
            }
        }
        #endregion

        #region [ Ajout - Suppression Piste ]

        /// <summary>
        /// Ajout d'une piste
        /// </summary>
        public void AddPiste()
        {
            PisteViewModel p = new PisteViewModel();
            p.Nom = "Nouvelle piste";
            if (Pistes.Count == 0)
                p.ID = 1;
            else
                p.ID = Pistes.Count + 1;
            Pistes.Add(p);
        }

        /// <summary>
        /// Suppression d'une piste
        /// </summary>
        public void RemovePiste()
        {
            if (SelectedPiste != null)
            {
                Pistes.Remove(SelectedPiste);
                SelectedPiste = null;

                int cpt = 0;
                // Actualisation des numéros de pistes
                foreach (PisteViewModel piste in Pistes)
                {
                    cpt++;
                    piste.ID = cpt;
                }
            }
        }
        #endregion
    }
}
