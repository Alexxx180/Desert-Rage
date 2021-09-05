using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Reload.xaml
    /// </summary>
    public partial class Reload : Window
    {
        public Reload(int code, string problem)
        {
            string[] enText = {
                "Encountered with connection problem. Contact with administrator.",
                "The video got some Exception! Contact with administrator.",

            };
            string[] ruText = {
                "Столкнулись с проблемой подключения. Свяжитесь с администратором.",
                "Возникла ошибка воспроизведения! Свяжитесь с администратором."
            };
            InitializeComponent();
            EN.Text = enText[code];
            RU.Text = ruText[code];
            Problem.Text = problem;
        }
        public Reload(string en, string ru, string problem)
        {
            InitializeComponent();
            EN.Text = en;
            RU.Text = ru;
            Problem.Text = problem;
        }
        public static void Reloading()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
