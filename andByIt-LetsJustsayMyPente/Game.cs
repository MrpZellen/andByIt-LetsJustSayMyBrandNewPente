using System;

namespace andByIt_LetsJustSayMyPente;

public class Game
{
    private Board board;
    private Player playerOne;
    private Player playerTwo;
    private Player currentPlayer;

    public Game(string playerOneName, string playerTwoName)
    {
        this.board = new Board();
        this.playerOne = new Player(1, playerOneName);
        this.playerTwo = new Player(2, playerTwoName);
    }

    public void makeMove(int x, int y)
    {
        board.getBoard()[x, y] = currentPlayer.PlayerInducator;
    }
    public void startGame()
    {
        
    }

    public void endGame()
    {
        
    }

    
    public void endTurn()
    {
        if (currentPlayer == playerOne)
        {
            currentPlayer = playerTwo;
        }
        else
        {
            currentPlayer = playerOne;
        }
    }

    public void printGame()
    {
        for (int i  = 0; i  < 19; i ++)
        {
            for (int j = 0; j < 19; j++)
            {
                Console.Write(board.getBoard()[i,j]);
                
            }
            Console.WriteLine("\n");
        }
    }
    
    
}