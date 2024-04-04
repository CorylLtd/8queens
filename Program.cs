using System.Text;

class EightQueensSolver
{
  // Size of the chessboard (8x8)
  public static int BoardSize = 8;
  private const char Queen = 'Q';
  private const char Empty = '.';

  // Function to print the board
  string SolutionToText(char[,] board)
  {
    var sb = new StringBuilder();
    for (int i = 0; i < BoardSize; i++)
    {
      for (int j = 0; j < BoardSize; j++)
        sb.Append($" {board[i, j]} ");
      sb.Append('\n');
    }
    return sb.ToString();
  }

  // A utility function to check if a queen can be placed on board[row][col]
  bool IsSafeSquare(char[,] board, int row, int col)
  {
    int i, j;

    // Check this row on left side
    for (i = 0; i < col; i++)
      if (board[row, i] == Queen)
        return false;

    // Check upper diagonal on left side
    for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
      if (board[i, j] == Queen)
        return false;

    // Check lower diagonal on left side
    for (i = row, j = col; j >= 0 && i < BoardSize; i++, j--)
      if (board[i, j] == Queen)
        return false;

    return true;
  }

  // A recursive utility function to solve the 8 Queens problem
  bool SolveRecursive(char[,] board, int col)
  {
    // If all queens are placed then return true
    if (col >= BoardSize)
      return true;

    // Consider this column and try placing this queen in all rows one by one
    for (int i = 0; i < BoardSize; i++)
    {
      // Check if the queen can be placed on board[i][col]
      if (IsSafeSquare(board, i, col))
      {
        // Place this queen in board[i][col]
        board[i, col] = Queen;

        // Recur to place rest of the queens
        if (SolveRecursive(board, col + 1))
          return true;

        // If placing queen in board[i][col] doesn't lead to a solution, then remove queen from board[i][col]
        board[i, col] = Empty; // BACKTRACK
      }
    }

    // If the queen cannot be placed in any row in this column col then return false
    return false;
  }

  // This function solves the 8 Queens problem using Backtracking
  public bool Solve()
  {
    char[,] board = new char[BoardSize, BoardSize];
    for (int i = 0; i < BoardSize; i++)
      for (int j = 0; j < BoardSize; j++)
        board[i, j] = Empty;

    if (!SolveRecursive(board, 0))
    {
      Console.WriteLine("Solution does not exist");
      return false;
    }

    Console.WriteLine(SolutionToText(board));
    return true;
  }

  // Main function
  public static void Main(string[] args)
  {
    var solver = new EightQueensSolver();
    solver.Solve();
  }
}
