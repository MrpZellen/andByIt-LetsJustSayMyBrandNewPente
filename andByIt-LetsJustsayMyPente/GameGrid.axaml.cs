using System;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using ArgumentNullException = System.ArgumentNullException;


namespace andByIt_LetsJustSayMyPente;

public partial class GameGrid : Window
{
    private Game game;
    private string playerOneName;
    private string playerTwoName;

    public string PlayerOneName
    {
        get => playerOneName;
        set => playerOneName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string PlayerTwoName
    {
        get => playerTwoName;
        set => playerTwoName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public GameGrid()
    {
        InitializeComponent();
    }

    public GameGrid(string playerOneName, string playerTwoName)
    {
        InitializeComponent();
        game = new Game(playerOneName, playerTwoName);
        game.printGame();
        var grid = this.FindControl<UniformGrid>("Test");
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                if (game.Board.checkSpot(i,j) == 0)
                {
                    var btn = new Button();
                    btn.Tag = (Row: i, Column: j);
                    btn.Click += onClick;
                    grid.Children.Add(btn);
                }
                else if (game.Board.checkSpot(i,j) == 1)
                {
                    grid.Children.Add(new Rectangle
                        { [Shape.FillProperty] = Brushes.White, Width = 10, Height = 10, Opacity = 0.9 });
                }
                else
                {
                    grid.Children.Add(new Rectangle
                        { [Shape.FillProperty] = Brushes.Black, Width = 10, Height = 10, Opacity = 0.9 });
                }
            }
        }
    }

    private void onClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is ValueTuple<int, int> indices)
        {
            var (row, column) = indices;
            // Console.WriteLine($"Row: {row}, Column: {column}");
            game.makeMove(row, column);
            game.CheckCaptures();
            updateBoard();
            if (game.CheckWin(row,column,game.CurrentPlayer.PlayerInducator) || game.CurrentPlayer.CaptureCount == 10)
            {
                Console.WriteLine("Player " + game.CurrentPlayer.Name + " wins!");
                // current player wins
                // brings to win screen // win screen will have a button to play again or main menu
            }
            else
            {
                //continue
                game.endTurn();
            }
        }
    }

    private void updateBoard()
    {
        var grid = this.FindControl<UniformGrid>("Test");
        grid.Children.Clear();
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 19; j++ )
            {
                if (game.Board.checkSpot(i,j) == 0)
                {
                    var btn = new Button();
                    btn.Tag = (Row: i, Column: j);
                    btn.Click += onClick;
                    grid.Children.Add(btn);
                }
                else if (game.Board.checkSpot(i,j) == 1)
                {
                    grid.Children.Add(new Rectangle
                        { [Shape.FillProperty] = Brushes.White, Width = 10, Height = 10, Opacity = 0.9 });
                }
                else
                {
                    grid.Children.Add(new Rectangle
                        { [Shape.FillProperty] = Brushes.Black, Width = 10, Height = 10, Opacity = 0.9 });
                }
            }
        }
    }
}