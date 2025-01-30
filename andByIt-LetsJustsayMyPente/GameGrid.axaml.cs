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
    private Button button;

    public GameGrid()
    {
        InitializeComponent();
        game = new Game("tom", "fred");
        game.printGame();

        button = new Button();
        var grid = this.FindControl<UniformGrid>("Test");
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                if (j % 3 == 0)
                {
                    grid.Children.Add(new Button {Click = onClick });
                }
                else if (j % 3 == 1)
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
        throw new NotImplementedException();
    }
}