using System.Windows;
using WpfApp1.ModelsDB;

namespace WpfApp1
{
    public partial class Add : Window
    {
        private User50Context _db;
        private Agent _agent;

        public Add(User50Context db)
        {
            InitializeComponent();
            _db = db;
        }

        public Add(User50Context db, Agent agent)
        {
            InitializeComponent();
            _db = db;
            _agent = agent;

            TxtFirstName.Text = agent.FirstName;
            TxtMiddleName.Text = agent.MiddleName;
            TxtLastName.Text = agent.LastName;
            TxtDealShare.Text = agent.DealShare?.ToString();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtFirstName.Text) ||
                string.IsNullOrWhiteSpace(TxtLastName.Text))
            {
                MessageBox.Show("Введите имя и фамилию");
                return;
            }

            decimal.TryParse(TxtDealShare.Text, out decimal dealShare);

            if (_agent == null)
            {
                var newAgent = new Agent
                {
                    FirstName = TxtFirstName.Text.Trim(),
                    MiddleName = TxtMiddleName.Text?.Trim(),
                    LastName = TxtLastName.Text.Trim(),
                    DealShare = (byte?)dealShare
                };
                _db.Agents.Add(newAgent);
            }
            else
            {
                _agent.FirstName = TxtFirstName.Text.Trim();
                _agent.MiddleName = TxtMiddleName.Text?.Trim();
                _agent.LastName = TxtLastName.Text.Trim();
                _agent.DealShare = (byte?)dealShare;
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