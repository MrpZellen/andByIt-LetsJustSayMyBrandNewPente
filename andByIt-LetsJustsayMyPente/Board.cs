namespace andByIt_LetsJustSayMyPente;

public class Board
{


    private int[,] board = new int[19, 19];

    public Board()
    {
        board = new int[19, 19];
    }

    public int[,] getBoard()
    {
        return board;
    }

    public int checkSpot(int x, int y)
    {
        return board[x, y];
    }
}