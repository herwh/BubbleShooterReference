using System.Collections.Generic;
using UnityEngine;

public class BubbleGrid
{
    private Bubble[,] _grid;
    private int _rows;
    private int _columns;

    public void SetSize(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
        _grid = new Bubble[rows, columns];
        GridHelper.Columns = columns;
    }

    public void AddBubble(int row, int column, Bubble newBubble)
    {
        _grid[row, column] = newBubble;
    }

    public List<Bubble> GetNeighbours(int row, int column)
    {
        var neighbours = new List<Bubble>();
        var columnOffset = 0;

        if (_grid[row, column] == null)
        {
            return neighbours;
        }

        AddNotNullNeighbours(neighbours, row, column - 1);
        AddNotNullNeighbours(neighbours, row, column + 1);

        if (GridHelper.IsOdd(row))
        {
            columnOffset = 1;
        }

        AddNotNullNeighbours(neighbours, row - 1, column - 1 + columnOffset);
        AddNotNullNeighbours(neighbours, row - 1, column + columnOffset);
        AddNotNullNeighbours(neighbours, row + 1, column - 1 + columnOffset);
        AddNotNullNeighbours(neighbours, row + 1, column + columnOffset);

        return neighbours;
    }

    public void InsertBubble(Bubble bubble, int row, int column, Color color)
    {
        
    }

    private void AddNotNullNeighbours(List<Bubble> neighbours, int row, int column)
    {
        if (row < 0 || row >= _rows || column < 0 || column >= _columns)
        {
            return;
        }

        if (_grid[row, column] != null)
        {
            neighbours.Add(_grid[row, column]);
        }
    }
}