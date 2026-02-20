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
        private void BtnAgentDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListView1.SelectedItem is Agent selected)
            {
                if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    using (var db = new User50Context())
                    {
                        var item = db.Agents.Find(selected.Id);
                        if (item != null)
                        {
                            db.Agents.Remove(item);
                            db.SaveChanges();
                            LoadDBInListView();
                        }
                    }
                }
            }
            else { MessageBox.Show("Выберите запись"); }
        }
        private void BtnAgentEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ListView1.SelectedItem is Agent selected)
            {
                using (var db = new User50Context())
                {
                    var item = db.Agents.Find(selected.Id);
                    if (item != null)
                    {
                        var window = new Add(db, item);
                        if (window.ShowDialog() == true)
                        {
                            LoadDBInListView();
                        }
                    }
                }
            }
            else { MessageBox.Show("Выберите запись"); }
        }
        private void BtnAgentAdd_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new User50Context())
            {
          
                var window = new Add(db);
                if (window.ShowDialog() == true)
                {
                    LoadDBInListView();
                }
            }
        }

        private void Button_Click_CreateClient(object sender, RoutedEventArgs e)
        {
            using (var db = new User50Context())
            {
                var add = new AddClient(db);
                if (add.ShowDialog() == true)
                {
                    LoadDBInListView();
                }
            }
        }
        private void Button_Click_EditClient(object sender, RoutedEventArgs e)
        {
            if (ListView2.SelectedItem is Client selected)
            {
                using (var db = new User50Context())
                {
                    var client = db.Clients.Find(selected.Id);
                    if (client != null)
                    {
                        var edit = new AddClient(db, client);
                        if (edit.ShowDialog() == true)
                        {
                            LoadDBInListView();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите запись");
            }
        }
        private void Button_Click_DeleteClient(object sender, RoutedEventArgs e)
        {
            if (ListView2.SelectedItem is Client selected)
            {
                if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    using (var db = new User50Context())
                    {
                        var client = db.Clients.Find(selected.Id);
                        if (client != null)
                        {
                            db.Clients.Remove(client);
                            db.SaveChanges();
                            LoadDBInListView();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите запись");
            }
        }
       
    }
}
        
        
    


