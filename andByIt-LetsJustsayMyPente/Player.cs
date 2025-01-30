using System;

namespace andByIt_LetsJustSayMyPente;

public class Player
{
    private string name;
    private int captureCount;
    private int playerInducator;

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int CaptureCount
    {
        get => captureCount;
        set => captureCount = value;
    }

    public int PlayerInducator
    {
        get => playerInducator;
        set => playerInducator = value;
    }

    public Player(int playerInducator, string name)
    {
        this.playerInducator = playerInducator;
        this.name = name;
        this.captureCount = 0;
    }
}