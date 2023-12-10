using System.Windows;
namespace Tetris
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        public void StartGame(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        public void ExitApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void ShowControls(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Controls:\n" +
                            "Left Arrow: Move block left\n" +
                            "Right Arrow: Move block right\n" +
                            "Up Arrow: Rotate block\n" +
                            "Down Arrow: Move block down\n" +
                            "ESC: Exit game");
        }
    }
}
