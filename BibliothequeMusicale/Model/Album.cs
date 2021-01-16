using System.Collections.Generic;

namespace BibliothequeMusicale
{
    public class Album
    {
        public string Compositeur { get; set; }
        public string Titre { get; set; }
        public List<Piste> Pistes { get; set; }

    }
}