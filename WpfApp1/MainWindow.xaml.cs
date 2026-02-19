using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ModelsDB;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadDBInListView();
        }


        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            return;
        }
        void LoadDBInListView()
        {
            using (User50Context _db = new User50Context())
            {
                int selectedIndex = ListView1.SelectedIndex;
                ListView1.ItemsSource = _db.Agents.ToList();
                ListView2.ItemsSource = _db.Clients.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == ListView1.Items.Count) selectedIndex--;
                    ListView1.SelectedIndex = selectedIndex;
                    ListView1.ScrollIntoView(ListView1.SelectedItem);
                }
                ListView1.Focus();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Add f = new Add();
            f.ShowDialog();
        }
    }
}
        
        
    


