using System.Windows;
using System.Windows.Controls;

namespace BibliothequeMusicale
{
    /// <summary>
    /// Logique d'interaction pour PisteListView.xaml
    /// </summary>
    public partial class PisteListView : UserControl
    {
        public PisteListView()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AlbumViewModel a)
            {
                a.AddPiste();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AlbumViewModel a)
            {
                a.RemovePiste();
            }
        }
    }
}
