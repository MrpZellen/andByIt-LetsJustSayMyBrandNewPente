using Avalonia.Controls;

namespace andByIt_LetsJustSayMyPente
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NavToPvp(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var pvpWindow = new GameGrid();
            pvpWindow.Show();
        }
        private void NavToAI(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var aiWindow = new AIGameWindow();
            aiWindow.Show();
        }
    }
}