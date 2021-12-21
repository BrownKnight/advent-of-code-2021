using System.Text.RegularExpressions;

namespace AdventOfCode;

public record BoardItem
{
    public BoardItem(int number)
    {
        Number = number;
    }
    public int Number { get; init; }

    public bool Selected { get; set; }
}

public record Board
{
    private const int NumRows = 5;
    private const int NumColumns = 5;

    public BoardItem[,] BoardItems { get; set; } = new BoardItem[NumRows, NumColumns];

    public static Board CreateFromString(string boardInput)
    {
        var board = new Board();
        var rows = boardInput.Split('\n');
        for (var i = 0; i < rows.Length; i++)
        {
            var columns = Regex.Replace(rows[i].Trim(), @"[ ]+", ",").Split(',');

            for (var j = 0; j < columns.Length; j++)
            {
                board.BoardItems[i, j] = new BoardItem(int.Parse(columns[j]));
            }
        }
        return board;
    }

    public bool ProcessBingoNumber(int number)
    {
        var boardItemWithNumber = BoardItems
            .Cast<BoardItem>()
            .FirstOrDefault(x => x.Number == number);

        if (boardItemWithNumber is not null)
        {
            boardItemWithNumber.Selected = true;
        }

        return CheckIfWinner();
    }

    public bool CheckIfWinner()
    {
        // Loop over all the rows and check if all the elements in the row have Selected=true
        for (var i = 0; i < NumRows; i++)
        {
            var allSelected = Enumerable
                .Range(0, NumColumns)
                .Select(j => BoardItems[i, j])
                .All(x => x.Selected);
            if (allSelected)
                return true;
        }

        // Loop over all the columns and check if all the elements in the row have Selected=true
        for (var i = 0; i < NumColumns; i++)
        {
            var allSelected = Enumerable
                .Range(0, NumRows)
                .Select(j => BoardItems[j, i])
                .All(x => x.Selected);
            if (allSelected)
                return true;
        }

        // Find the first diagonal (where i, j are the same)
        var firstDiagonalAllSelected = Enumerable
            .Range(0, NumColumns)
            .Select(i => BoardItems[i, i])
            .All(x => x.Selected);
        if (firstDiagonalAllSelected)
            return true;

        var inverseDiagonalAllSelected = Enumerable
            .Range(0, NumColumns)
            .Select(i => BoardItems[i, (NumColumns - 1) - i])
            .All(x => x.Selected);
        if (inverseDiagonalAllSelected)
            return true;

        return false;
    }
}

public class Day4
{
    public static List<Board> CreateBoards(IEnumerable<string> boardInputs)
    {
        var boards = new List<Board>();
        foreach (var boardInput in boardInputs)
        {
            boards.Add(Board.CreateFromString(boardInput));
        }
        return boards;
    }

    public static Board? ProcessBingoNumber(IEnumerable<Board> boards, int number)
    {
        Board? winningBoard = null;
        foreach (var board in boards)
        {
            var isWinner = board.ProcessBingoNumber(number);
            if (isWinner && winningBoard is null)
                winningBoard = board;
        }
        return winningBoard;
    }

    public static int ProcessInput(string input)
    {
        var inputs = input.Split("\n\n") ?? throw new InvalidOperationException();

        var numbersToPlay = inputs[0].Split(',').Select(int.Parse);

        var boardInputs = inputs[1..];
        var boards = CreateBoards(boardInputs);
        Board? winningBoard = default;
        int lastNumber = 0;
        foreach (var number in numbersToPlay)
        {
            winningBoard = ProcessBingoNumber(boards, number);
            if (winningBoard is not null)
            {
                Console.WriteLine("We have a winning board!");
                lastNumber = number;
                break;
            }
        }

        if (winningBoard is null)
        {
            throw new InvalidOperationException("No board won!");
        }

        var sumOfUnselectedNumbers = winningBoard.BoardItems
            .Cast<BoardItem>()
            .Where(x => !x.Selected)
            .Sum(x => x.Number);
        var score = sumOfUnselectedNumbers * lastNumber;
        
        return score;
    }

    public static int ProcessInputForFinalWinningBoard(string input)
    {
        var inputs = input.Split("\n\n") ?? throw new InvalidOperationException();

        var numbersToPlay = inputs[0].Split(',').Select(int.Parse);

        var boardInputs = inputs[1..];
        var boards = CreateBoards(boardInputs);
        Board? finalWinningBoard = default;
        int lastNumber = 0;
        foreach (var number in numbersToPlay)
        {
            var winningBoard = ProcessBingoNumber(boards, number);
            if (winningBoard is not null)
            {
                boards.RemoveAll(x => x.CheckIfWinner());
                finalWinningBoard = winningBoard;
                lastNumber = number;
            }
        }

        if (finalWinningBoard is null)
        {
            throw new InvalidOperationException("No board won!");
        }

        var sumOfUnselectedNumbers = finalWinningBoard.BoardItems
            .Cast<BoardItem>()
            .Where(x => !x.Selected)
            .Sum(x => x.Number);
        var score = sumOfUnselectedNumbers * lastNumber;

        return score;
    }
}
