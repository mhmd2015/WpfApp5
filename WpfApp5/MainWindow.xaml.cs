using MasterBlazor.WPF.Lib.Auth;
using MasterBlazor.WPF.UC.LoginPage;
using MasterBlazor.WPF.UC.RestForm;
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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginWindow loginWindow;
        RestManager restManager;
        AuthManager authManager;
        public MainWindow()
        {
            InitializeComponent();
        }
        public async Task Login(string url)
        {
            if (loginWindow == null)
            {
                loginWindow = new LoginWindow(url);
                loginWindow.LoginCompleted += LoginWindow_LoginCompleted;
            }

            bool? result = loginWindow.ShowDialog();




        }

        private void LoginWindow_LoginCompleted(object? sender, string e)
        {
            loginWindow.Close();
            GetData();
        }

        private async void btnGet_Click(object sender, RoutedEventArgs e)
        {
            if (txtUrl.Text != "" && txtUrl.Text != "https://")
            {
                await GetData();
            }
        }

        private async void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (txtUrl.Text != "" && txtUrl.Text != "https://")
            {
                if (authManager == null)
                    authManager = new AuthManager(txtUrl.Text);
                authManager.Reset();

                if (restManager == null)
                    restManager = new RestManager(null, txtUrl.Text);
                restManager.Reset();
            }
        }

        private async Task GetData()
        {
            if (authManager == null)
                authManager = new AuthManager(txtUrl.Text);

            var auth = authManager.Load();

            if (auth == null || auth.Count == 0)
            {
                if (loginWindow == null)
                    await Login(txtUrl.Text);
            }
            else if (txtAPI.Text != "" && txtAPI.Text != "/")
            {

                if (restManager == null)
                    restManager = new RestManager(auth, txtUrl.Text);
                txtResult.Text = await restManager.Get(txtAPI.Text);
            }
        }
        private void AddSettingItem_Click(object sender, RoutedEventArgs e)
        {
            comboSettings1.AddItem(txtUrl.Text, txtAPI.Text);
        }

        private void comboSettings1_ComboBoxItemSelected(object sender, ComboBoxItemData e)
        {
            txtUrl.Text = e.SiteUrl;
            txtAPI.Text = e.ApiUrl;

            if (restManager != null)
            {
                restManager.Dispose();
                restManager = null;
                GetData();
            }
        }
    }
}