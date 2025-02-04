using Avalonia.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace andByIt_LetsJustSayMyPente;

public partial class LoseScreen : Window
{
    public LoseScreen()
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