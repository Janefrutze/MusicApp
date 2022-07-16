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

namespace MusicApp.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        public SearchView()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigatedEventHandler handler = (NavigatedEventHandler)sender;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonGoToMainView_OnClick(Object sender, RoutedEventArgs e)
        {
            //ContentFrame.Navigate(Uri  "./MainWindow.xaml");
        }
    }
}
