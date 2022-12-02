using System;
using System.Collections.Generic;

namespace GameOfLife;

public class GameOfLife
{
    public string Process(string input)
    {
        (int rows, int columns, string map) = GetInputAndSize(input);
        
        return map;
    }

    private (int rows, int columns, string map) GetInputAndSize(string input)
    {
        List<string> lines = new (input.Split("\n"));
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

        string map = string.Join("\n", lines);
        return (rows, columns, map);
    }

    private bool InputHasSize(string input)
    {
        return input[0] != '.' && input[0] != '*';
    }

    private bool HasNeighbor(string input, int row, int columns)
    {
        (int row, int col) N_Neighbor;
        (int row, int col) NW_Neighbor;
        (int row, int col) W_Neighbor;
        (int row, int col) SW_Neighbor;
        (int row, int col) S_Neighbor;
        (int row, int col) SE_Neighbor;
        (int row, int col) E_Neighbor;
        (int row, int col) NE_Neighbor;
        return false;
    }
    
}