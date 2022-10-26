public class BubbleGrid
{
    private Bubble[,] _grid;

    public void SetSize(int rows, int columns)
    {
        _grid = new Bubble[rows, columns];
    }

    public void AddBubble(int row, int column, Bubble newBubble)
    {
        _grid[row, column] = newBubble;
    }
}
