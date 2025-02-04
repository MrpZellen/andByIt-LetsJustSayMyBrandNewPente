using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ArgumentNullException = System.ArgumentNullException;

namespace andByIt_LetsJustSayMyPente;

public partial class AIGameWindow : Window
{
    private Game game;
    private string playerOneName;
    private string playerTwoName;
    public string InARowString { get; set; } = "nobody is close to winning yet!";
    private TextBlock textBlock;
    //win binding update variable
    private string _isCloseToWin = "not close yet....";

    public string IsCloseToWin
    {
        get => _isCloseToWin;
        set => _isCloseToWin = value ?? throw new ArgumentNullException(nameof(value));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    public string PlayerOneName
    {
        get => playerOneName;
        set
        {
            if (_isCloseToWin != value)
            {
                _isCloseToWin = value;
                OnPropertyChanged();
            }
        }
    }

    public string PlayerTwoName
    {
        get => playerTwoName;
        set => playerTwoName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public AIGameWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    public AIGameWindow(string playerOneName, string playerTwoName)
    {
        InitializeComponent();
        game = new Game(playerOneName, playerTwoName);
        game.printGame();
        var grid = this.FindControl<UniformGrid>("Test");
        textBlock = this.FindControl<TextBlock>("tellUsers");
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                if (game.Board.checkSpot(i, j) == 0)
                {
                    var btn = new Button();
                    btn.Tag = (Row: i, Column: j);
                    btn.Click += onClick;
                    grid.Children.Add(btn);
                }
                else if (game.Board.checkSpot(i, j) == 1)
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
            textBlock.Text = checkForUserInfo(game.CheckForFour(row, column, game.CurrentPlayer.PlayerInducator),
                game.CheckForThree(row, column, game.CurrentPlayer.PlayerInducator));
            if (game.CheckWin(row, column, game.CurrentPlayer.PlayerInducator) || game.CurrentPlayer.CaptureCount == 10)
            {
                Console.WriteLine("Player " + game.CurrentPlayer.Name + " wins!");
                var WinScreen = new WinScreen(game.CurrentPlayer.Name);
                WinScreen.Show();
                Close();
                // current player wins
                // brings to win screen // win screen will have a button to play again or main menu
            }
            else
            {
                AITurn();
                game.CheckCaptures();
                updateBoard();
                if (game.CheckWin(row, column, game.CurrentPlayer.PlayerInducator) || game.CurrentPlayer.CaptureCount == 10)
                {
                    Console.WriteLine("Player " + game.CurrentPlayer.Name + " wins!");
                    var losScreen = new LoseScreen();
                    losScreen.Show();
                    Close();
                    
                }
                
            }
        }
    }

    private void updateBoard()
    {
        var grid = this.FindControl<UniformGrid>("Test");
        grid.Children.Clear();
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                if (game.Board.checkSpot(i, j) == 0)
                {
                    var btn = new Button();
                    btn.Tag = (Row: i, Column: j);
                    btn.Click += onClick;
                    grid.Children.Add(btn);
                }
                else if (game.Board.checkSpot(i, j) == 1)
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

    private void AITurn()
    {
        int row;
        int col;
        int spot = -1;
        do
        {
            Random random = new Random();
            row = (int)random.NextInt64(game.Board.getBoard().GetLength(0));
            col = (int)random.NextInt64(game.Board.getBoard().GetLength(1));
            spot = game.Board.getBoard()[row, col];
        } while (spot != 0);
        game.Board.getBoard()[row, col] = 2;
    }

    private string checkForUserInfo(int four, int three)
    {
        if (four == 4)
        {
            return "Tessera";
        }else if (three == 3)
        {
            return "Tria";
        }
        else
        {
            return "";
        }
    }
}