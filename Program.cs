using System.Text;

class EightQueensSolver
{
  private const char Queen = 'Q';
  private const char Empty = '.';
  private readonly int boardSize;
  private readonly char[,] board;


  public EightQueensSolver(int boardSize = 8)
  {
    this.boardSize = boardSize;
    board = new char[boardSize, boardSize];
  }

  // Function to print the board
  string SolutionToText()
  {
    var sb = new StringBuilder();
    for (int i = 0; i < boardSize; i++)
    {
      for (int j = 0; j < boardSize; j++)
        sb.Append($" {board[i, j]} ");
      sb.Append('\n');
    }
    return sb.ToString();
  }

  // A utility function to check if a queen can be placed on board[row][col]
  bool IsSafeSquare(int row, int col)
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
    for (i = row, j = col; j >= 0 && i < boardSize; i++, j--)
      if (board[i, j] == Queen)
        return false;

    return true;
  }

  // A recursive utility function to solve the 8 Queens problem
  bool SolveRecursive(int col)
  {
    // If all queens are placed then return true
    if (col >= boardSize)
      return true;

    // Consider this column and try placing this queen in all rows one by one
    for (int i = 0; i < boardSize; i++)
    {
      // Check if the queen can be placed on board[i][col]
      if (IsSafeSquare(i, col))
      {
        // Place this queen in board[i][col]
        board[i, col] = Queen;

        // Recur to place rest of the queens
        if (SolveRecursive(col + 1))
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
    for (int i = 0; i < boardSize; i++)
      for (int j = 0; j < boardSize; j++)
        board[i, j] = Empty;

    return SolveRecursive(0);
  }

  // Main function
  public static void Main(string[] args)
  {
    int boardSize = (args.Length > 0 && int.TryParse(args[0], out boardSize) && boardSize > 0) ? boardSize : 8;
    Console.WriteLine($"Solving the {boardSize} Queens problem");
    var solver = new EightQueensSolver(boardSize);
    solver.Solve();
    if (solver.Solve())
    {
      Console.WriteLine(solver.SolutionToText());
    }
    else
    {
      Console.WriteLine($"Solution does not exist for a {boardSize}x{boardSize} board.");
    }
  }
}
