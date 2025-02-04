using System;

namespace andByIt_LetsJustSayMyPente;

public class Game
{
    private Board board;
    private Player playerOne;
    private Player playerTwo;
    private Player currentPlayer;

    public Board Board
    {
        get => board;
        set => board = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Player PlayerOne
    {
        get => playerOne;
        set => playerOne = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Player PlayerTwo
    {
        get => playerTwo;
        set => playerTwo = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Player CurrentPlayer
    {
        get => currentPlayer;
        set => currentPlayer = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Game(string playerOneName, string playerTwoName)
    {
        this.board = new Board();
        this.playerOne = new Player(1, playerOneName);
        this.playerTwo = new Player(2, playerTwoName);
        this.currentPlayer = this.playerOne;
    }

    public void makeMove(int x, int y)
    {
        board.getBoard()[x, y] = currentPlayer.PlayerInducator;
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
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                Console.Write(board.getBoard()[i, j]);

            }

            Console.WriteLine("\n");
        }
    }

    public bool CheckWin(int row, int col, int player)
    {
        int numRows = board.getBoard().GetLength(0);
        int numCols = board.getBoard().GetLength(1);

        // These directions cover horizontal, vertical, and the two diagonal directions.
        int[][] directions = new int[][]
        {
            new int[] { 0, 1 }, // Horizontal
            new int[] { 1, 0 }, // Vertical
            new int[] { 1, 1 }, // Diagonal (top-left to bottom-right)
            new int[] { 1, -1 } // Diagonal (top-right to bottom-left)
        };

        // Check each direction
        foreach (var direction in directions)
        {
            int count = 1; // Count the stone just placed
            int dRow = direction[0];
            int dCol = direction[1];

            // Check in the positive direction
            int r = row + dRow;
            int c = col + dCol;
            while (r >= 0 && r < numRows && c >= 0 && c < numCols && board.getBoard()[r, c] == player)
            {
                count++;
                r += dRow;
                c += dCol;
            }

            // Check in the negative direction (the opposite direction)
            r = row - dRow;
            c = col - dCol;
            while (r >= 0 && r < numRows && c >= 0 && c < numCols && board.getBoard()[r, c] == player)
            {
                count++;
                r -= dRow;
                c -= dCol;
            }

            // If we've found 5 or more in a row, return true
            if (count >= 5)
                return true;
        }

        // No win condition met
        return false;
    }

    public void CheckCaptures()
    {
        int numRows = board.getBoard().GetLength(0);
        int numCols = board.getBoard().GetLength(1);
        bool player1Captured = false;
        bool player2Captured = false;

        // Directions to check
        int[][] directions = new int[][]
        {
                new int[] { 0, 1 }, // Right
                new int[] { 1, 0 }, // Down
                new int[] { 1, 1 }, // Down-right
                new int[] { 1, -1 }, // Down-left
                new int[] { 0, -1 }, // Left
                new int[] { -1, 0 }, // Up
                new int[] { -1, -1 }, // Up-left
                new int[] { -1, 1 } // Up-right
        };

        // looks for a capure on the board
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                int player = board.getBoard()[row, col];
                // Skip empty spaces
                if (player == 0)
                {
                    continue;
                }

                int opponent = (player == 1) ? 2 : 1;

                foreach (var dir in directions)
                {
                    int dRow = dir[0];
                    int dCol = dir[1];

                    int r1 = row + dRow;
                    int c1 = col + dCol;
                    int r2 = row + 2 * dRow;
                    int c2 = col + 2 * dCol;
                    int r3 = row + 3 * dRow;
                    int c3 = col + 3 * dCol;

                    if (IsInBounds(r1, c1, numRows, numCols) &&
                        IsInBounds(r2, c2, numRows, numCols) &&
                        IsInBounds(r3, c3, numRows, numCols))
                    {
                        if (board.getBoard()[r1, c1] == opponent &&
                            board.getBoard()[r2, c2] == opponent &&
                            board.getBoard()[r3, c3] == player)
                        {
                            // Capture found
                            if (player == 1)
                                player1Captured = true;
                            else
                                player2Captured = true;

                            // Remove captured stuff
                            board.getBoard()[r1, c1] = 0;
                            board.getBoard()[r2, c2] = 0;
                        }
                    }
                }
            }
        }

        if (player1Captured && !player2Captured)
        {
            PlayerOne.CaptureCount += 2;
        }
        else if (player2Captured && !player1Captured)
        {
            PlayerTwo.CaptureCount += 2;
        }
        else if (player1Captured && player2Captured)
        {
            PlayerOne.CaptureCount += 2;
            PlayerTwo.CaptureCount += 2;
        }
    }

    private bool IsInBounds(int r, int c, int numRows, int numCols)
    {
        return r >= 0 && r < numRows && c >= 0 && c < numCols;
    }
}