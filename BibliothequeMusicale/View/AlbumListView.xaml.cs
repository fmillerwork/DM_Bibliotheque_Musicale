using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BibliothequeMusicale
{
    /// <summary>
    /// Logique d'interaction pour AlbumListView.xaml
    /// </summary>
    public partial class AlbumListView : UserControl
    {
        public AlbumListView()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel m)
            {
                m.AddAlbum();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel m)
            {
                m.RemoveAlbum();
            }
        }
    }
}
