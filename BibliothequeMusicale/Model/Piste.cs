namespace BibliothequeMusicale
{
    public class Piste
    {
        public int ID { get; set; }
        public string Nom { get; set; }

        public Piste(int id, string nom)
        {
            ID = id;
            Nom = nom;
        }

        public Piste()
        {
        }

    }
}
