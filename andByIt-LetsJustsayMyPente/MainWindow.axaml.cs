using Avalonia.Controls;

namespace andByIt_LetsJustSayMyPente
{
    public partial class MainWindow : Window
    {
        TextBox textBox1;
        TextBox textBox2;
        private string playerOneName;
        private string playerTwoName;
        public MainWindow()
        {
            InitializeComponent();
            textBox1 = this.FindControl<TextBox>("P1");
            textBox2 = this.FindControl<TextBox>("P2");
        }

        private void NavToPvp(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            getPlayerOneName(false);
            var pvpWindow = new GameGrid(playerOneName, playerTwoName);
            pvpWindow.Show();
        }
        private void NavToAI(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            getPlayerOneName(true);
            var aiWindow = new AIGameWindow();
            aiWindow.Show();
        }

        public void getPlayerOneName(bool AI)
        {
            if (AI)
            {
                if (textBox1.Text == null)
                {
                    playerOneName = "Player1";
                }

                if (textBox2.Text == null)
                {
                    playerTwoName = "AI";
                }
            }
            else
            {
                if (textBox1.Text == null)
                {
                    playerOneName = "Player1";
                }

                if (textBox2.Text == null)
                {
                    playerTwoName = "Player2";
                }
            }

        }

    }
}