using System;

class EightQueens
{
  // Size of the chessboard (8x8)
  public static int N = 8;

  // Function to print the board
  void PrintSolution(int[,] board)
  {
    for (int i = 0; i < N; i++)
    {
      for (int j = 0; j < N; j++)
        Console.Write(" " + board[i, j] + " ");
      Console.WriteLine();
    }
  }

  // A utility function to check if a queen can be placed on board[row][col]
  bool IsSafe(int[,] board, int row, int col)
  {
    int i, j;

    // Check this row on left side
    for (i = 0; i < col; i++)
      if (board[row, i] == 1)
        return false;

    // Check upper diagonal on left side
    for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
      if (board[i, j] == 1)
        return false;

    // Check lower diagonal on left side
    for (i = row, j = col; j >= 0 && i < N; i++, j--)
      if (board[i, j] == 1)
        return false;

    return true;
  }

  // A recursive utility function to solve the 8 Queens problem
  bool SolveNQUtil(int[,] board, int col)
  {
    // If all queens are placed then return true
    if (col >= N)
      return true;

    // Consider this column and try placing this queen in all rows one by one
    for (int i = 0; i < N; i++)
    {
      // Check if the queen can be placed on board[i][col]
      if (IsSafe(board, i, col))
      {
        // Place this queen in board[i][col]
        board[i, col] = 1;

        // Recur to place rest of the queens
        if (SolveNQUtil(board, col + 1))
          return true;

        // If placing queen in board[i][col] doesn't lead to a solution, then remove queen from board[i][col]
        board[i, col] = 0; // BACKTRACK
      }
    }

    // If the queen cannot be placed in any row in this column col then return false
    return false;
  }

  // This function solves the 8 Queens problem using Backtracking
  public bool SolveNQ()
  {
    int[,] board = new int[N, N];

    if (!SolveNQUtil(board, 0))
    {
      Console.WriteLine("Solution does not exist");
      return false;
    }

    PrintSolution(board);
    return true;
  }

  // Main function
  public static void Main(String[] args)
  {
    EightQueens Queen = new EightQueens();
    Queen.SolveNQ();
  }
}
