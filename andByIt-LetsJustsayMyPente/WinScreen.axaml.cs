using Avalonia.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

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
    public WinScreen()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void GoToMenu(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow win = new MainWindow();
        win.Show();
        Close();
    }
}