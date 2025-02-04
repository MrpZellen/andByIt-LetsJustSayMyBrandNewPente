using Avalonia.Controls;

namespace andByIt_LetsJustSayMyPente;

public partial class AIGameWindow : Window
{
    public string InARowString { get; set; } = "nobody is close to winning yet!";
    public AIGameWindow()
    {
        InitializeComponent();
    }
}