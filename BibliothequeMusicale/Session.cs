using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace BibliothequeMusicale
{
    public class Session
    {
        // Nom du fichier
        private const string FILENAME = "session.xml";

        private readonly XmlWriterSettings _xmlWriterSettings;

        public List<Album> Albums { get; set; }

        public Session()
        {
            Albums = new List<Album>();
            _xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true, // Activation de l'indentation
                IndentChars = ("\t"),   // En suivant une tabulation
                OmitXmlDeclaration = true   // Supprime les déclaration XML en début de document
            };
        }

        /// <summary>
        /// Charge les albums depuis le fichier xml. Retourne une Session dont le champs Album correspond au contenu du fichier.
        /// </summary>
        public static Session Load()
        {
            Session session = new Session();

            if (File.Exists(FILENAME) && new FileInfo(FILENAME).Length != 0) // fichier existe et non vide
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Session));
                StreamReader streamReader = new StreamReader(FILENAME);

                try
                {
                    session = (Session)serializer.Deserialize(streamReader);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite lors de la déserialisation : " + ex.Message);
                }
            }
            return session;
        }

        /// <summary>
        /// Sauvegarde les albums dans le fichier xml.
        /// </summary>
        public void Save()
        {
            var emptyNamespace = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(Session));
            using (XmlWriter writer = XmlWriter.Create(FILENAME, _xmlWriterSettings))
            {
                serializer.Serialize(writer, this, emptyNamespace);
            }
        }
    }
}
