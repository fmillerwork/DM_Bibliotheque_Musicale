using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BibliothequeMusicale
{
    class MainViewModel : Observable
    {
        #region [ Champs ]
        private Session _session = new Session();
        public ObservableCollection<AlbumViewModel> Albums { get; }

        private AlbumViewModel _selectedAlbum;
        public AlbumViewModel SelectedAlbum
        {
            get => _selectedAlbum;
            set => SetProperty(ref _selectedAlbum, value);
        }

        #endregion

        #region [ Constructeur ]
        public MainViewModel()
        {
            Albums = new ObservableCollection<AlbumViewModel>();
            _session = Session.Load();
            foreach (Album album in _session.Albums)
            {
                Albums.Add(new AlbumViewModel(album));
            }
        }
        #endregion

        #region [ Ajout - Suppression Album ]
        public void AddAlbum()
        {
            AlbumViewModel a = new AlbumViewModel();
            a.Titre = "Nouvel album";
            a.Compositeur = "Compositeur";

            Albums.Add(a);
            SelectedAlbum = a;
        }

        public void RemoveAlbum()
        {
            if (_selectedAlbum != null)
            {
                Albums.Remove(_selectedAlbum);
                SelectedAlbum = null;
            }
        }
        #endregion

        #region [ Méthodes ]

        /// <summary>
        /// Transforme une ObservableCollection d'AlbumViewModel en List d'Album
        /// </summary>
        /// <param name="albumVMList"></param>
        /// <returns>AlbumModelList</returns>
        private List<Album> AlbumsVMToAlbumModel(ObservableCollection<AlbumViewModel> albumVMList)
        {
            List<Album> albumList = new List<Album>();
            foreach (AlbumViewModel avm in albumVMList)
            {
                Album album = new Album() { Compositeur = avm.Compositeur, Titre = avm.Titre, Pistes = new List<Piste>() };
                foreach (PisteViewModel pvm in avm.Pistes)
                {
                    album.Pistes.Add(new Piste(pvm.ID, pvm.Nom));
                    ;
                }
                albumList.Add(album);
            }
            return albumList;
        }

        /// <summary>
        /// Execute une sauvegarde de la session en cours.
        /// </summary>
        public void AppClosing()
        {
            _session = new Session();
            _session.Albums = AlbumsVMToAlbumModel(Albums);
            _session.Save();
        }
        #endregion
    }

}
