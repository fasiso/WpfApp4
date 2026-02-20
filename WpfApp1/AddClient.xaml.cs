using System.Windows;
using WpfApp1.ModelsDB;

namespace WpfApp1
{
    public partial class AddClient : Window
    {
        private User50Context _db;
        private Client _client;

        // Для добавления
        public AddClient(User50Context db)
        {
            InitializeComponent();
            _db = db;
        }

        // Для редактирования
        public AddClient(User50Context db, Client client)
        {
            InitializeComponent();
            _db = db;
            _client = client;

            TxtFirstName.Text = client.FirstName;
            TxtMiddleName.Text = client.MiddleName;
            TxtLastName.Text = client.LastName;
            TxtPhone.Text = client.Phone;
            TxtEmail.Text = client.Email;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            // Проверка: имя и фамилия обязательны
            if (string.IsNullOrWhiteSpace(TxtFirstName.Text) ||
                string.IsNullOrWhiteSpace(TxtLastName.Text))
            {
                MessageBox.Show("Введите имя и фамилию");
                return;
            }

            
            string phone = TxtPhone.Text?.Trim();
            string email = TxtEmail.Text?.Trim();

            if (string.IsNullOrWhiteSpace(phone) && string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Заполните телефон или почту");
                return;
            }

            if (_client == null)
            {
               
                var newClient = new Client
                {
                    FirstName = TxtFirstName.Text.Trim(),
                    MiddleName = TxtMiddleName.Text?.Trim(),
                    LastName = TxtLastName.Text.Trim(),
                    Phone = phone,
                    Email = email
                };
                _db.Clients.Add(newClient);
            }
            else
            {
                
                _client.FirstName = TxtFirstName.Text.Trim();
                _client.MiddleName = TxtMiddleName.Text?.Trim();
                _client.LastName = TxtLastName.Text.Trim();
                _client.Phone = phone;
                _client.Email = email;
            }

            _db.SaveChanges();
            this.DialogResult = true;
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}