using System;
using System.Collections.Generic;
using System.Linq;

public class GameOfLife
{
    private const char AliveCell = '*';
    private const char DeadCell = '.';

    public string Process(string input)
    {
        (int rows, int columns, List<string> lines) = GetInputAndSize(input);

        var output = lines.ToList();

        for (var row = 0; row < rows; row++)
        {
            for (var column = 0; column < columns; column++)
            {
                if (IsAlive(lines, row, column))
                {
                    if (CountNeighbors(lines, row, column, AliveCell) < 2)
                    {
                        var str = output[row];
                        var charArray = str.ToCharArray();
                        charArray[column] = DeadCell;
                        output[row] = new string(charArray);
                    }
                    else if (CountNeighbors(lines, row, column, AliveCell) > 3)
                    {
                        var str = output[row];
                        var charArray = str.ToCharArray();
                        charArray[column] = DeadCell;
                        output[row] = new string(charArray);
                    }
                }
                else
                {
                    if (CountNeighbors(lines, row, column, AliveCell) == 3)
                    {
                        var str = output[row];
                        var charArray = str.ToCharArray();
                        charArray[column] = AliveCell;
                        output[row] = new string(charArray);
                    }
                }
            }
        }

        return string.Join("\n", output) + "\n";
    }

    private bool IsAlive(List<string> lines, int row, int column)
    {
        var character = lines[row][column];
        return character == AliveCell;
    }

    private (int rows, int columns, List<string> lines) GetInputAndSize(string input)
    {
        List<string> lines = new (input.Split("\n", StringSplitOptions.RemoveEmptyEntries));
        int rows;
        int columns;
        if (InputHasSize(input))
        {
            try
            {
                string[] sizes = lines[0].Split(" ");
                rows = int.Parse(sizes[0]);
                columns = int.Parse(sizes[1]);
                lines.RemoveAt(0);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Input is malformed");
            }
        }
        else
        {
            rows = lines.Count;
            columns = lines[0].Length;
        }
        
        return (rows, columns, lines);
    }

    private bool InputHasSize(string input)
    {
        return input[0] != '.' && input[0] != AliveCell;
    }

    private int CountNeighbors(List<string> lines, int row, int column, char compareTo)
    {
        var rows = lines.Count;
        var columns = lines[0].Length;

        var counter = 0;
        
        for (var i = Math.Max(0, row - 1); i <= Math.Min(row + 1, rows - 1); i++)
        {
            for (var j = Math.Max(0, column - 1); j <= Math.Min(column + 1, columns - 1); j++)
            {
                if (i == row && j == column)
                    continue;

                if (compareTo == lines[i][j])
                    counter++;
            }
        }

        return counter;
    }
    
}
