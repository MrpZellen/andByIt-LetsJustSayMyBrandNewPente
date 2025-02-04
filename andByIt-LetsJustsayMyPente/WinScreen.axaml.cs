using Avalonia.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using Avalonia.Interactivity;

namespace andByIt_LetsJustSayMyPente;

public partial class WinScreen : Window
{
    //win binding update variable
    private string _winningPlayer = "Congrats On Winning!";
    public string WinningPlayer
    {
        get => _winningPlayer;
        set => _winningPlayer = value ?? throw new ArgumentNullException(nameof(value));
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public WinScreen(string winningPlayer)
    {
        InitializeComponent();
        DataContext = this;
        var text = this.FindControl<TextBlock>("WinningTextBlock");
        text.Text += "\n" + winningPlayer;
        
    }

    private void GoToMenu(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow win = new MainWindow();
        win.Show();
        Close();
    }

}