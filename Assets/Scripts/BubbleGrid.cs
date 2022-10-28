using System.Collections.Generic;
using UnityEngine;

public class BubbleGrid
{
    private Bubble[,] _grid;
    private int _rows;
    private int _columns;
    private int _clusterFactor;

    public void SetSize(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
        _grid = new Bubble[rows, columns];
        GridHelper.Columns = columns;
        GridHelper.MaxRows = rows;
    }

    public void AddBubble(int row, int column, Bubble newBubble)
    {
        _grid[row, column] = newBubble;
        newBubble.Row = row;
        newBubble.Column = column;
    }

    public void SetClusterFactor(int clusterFactor)
    {
        _clusterFactor = clusterFactor;
    }

    public void InsertBubble(Bubble bubble, int row, int column, Color color)
    {
        AddBubble(row,column,bubble);
        var visitedBubbles = new HashSet<Bubble>();

        ClusterSearch(visitedBubbles, bubble, row, column);
        
        if (visitedBubbles.Count >= _clusterFactor)
        {
            foreach (var visitedBubble in visitedBubbles)
            {
                _grid[visitedBubble.Row, visitedBubble.Column] = null;
                Object.Destroy(visitedBubble.gameObject);
            }
        }
    }
    private List<Bubble> GetNeighbours(int row, int column)
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

    private void ClusterSearch(HashSet<Bubble> visitedBubbles, Bubble bubble, int row, int column)
    {
        var neighboursWithSameColor = new Queue<Bubble>();

        var bubbleNeighbours = GetNeighbours(row, column);
        visitedBubbles.Add(bubble);

        for (int i = 0; i < bubbleNeighbours.Count; i++)
        {
            if (bubbleNeighbours[i].Color == bubble.Color && !visitedBubbles.Contains(bubbleNeighbours[i]))
            {
                neighboursWithSameColor.Enqueue(bubbleNeighbours[i]);
            }
        }
        
        while (neighboursWithSameColor.Count > 0)
        {
            var neighbour = neighboursWithSameColor.Dequeue();
            ClusterSearch(visitedBubbles, neighbour, neighbour.Row, neighbour.Column);
        }
    }
}