using Data;
using UnityEngine;

public class GridBuilder : MonoBehaviour
{
    [SerializeField] private Bubble _bubble;
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;
    [SerializeField] private int _maxRows;
    [SerializeField] private int _bubbleSkipProbability;
    [SerializeField] private BubbleData _bubbleData;
    [SerializeField] private int _bubbleClusterFactor;

    public BubbleGrid BubbleGrid => _bubbleGrid;

    private float _halfBubbleWidth;
    private readonly BubbleGrid _bubbleGrid = new();

    private void Awake()
    {
        _bubbleGrid.SetSize(_maxRows, _columns);
        _bubbleGrid.SetClusterFactor(_bubbleClusterFactor);
        Build();
    }

    private void Build()
    {
        var bubbleSize = _bubble.GetSize();
        var halfBubbleWidth = bubbleSize.x * 0.5f;
        var halfBubbleHeight = bubbleSize.y * 0.5f;
        var startPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));

        startPosition.x += halfBubbleWidth;
        startPosition.y -= halfBubbleHeight;
        startPosition.z = 0;

        for (int row = 0; row < _rows; row++)
        {
            for (int column = 0; column < _columns; column++)
            {
                if (SkipBubble())
                {
                    continue;
                }

                var startOffset = Vector3.zero;

                if (GridHelper.IsOdd(row))
                {
                    startOffset.x = halfBubbleWidth;
                }

                var position = startPosition + startOffset + new Vector3(bubbleSize.x * column, -bubbleSize.y * row, 0);

                CreateBubble(position, column, row);
            }
        }
    }

    private void CreateBubble(Vector3 position, int column, int row)
    {
        var newBubble = Instantiate(_bubble, position, Quaternion.identity);
        newBubble.Color = _bubbleData.GetRandomColor();
        _bubbleGrid.AddBubble(row, column, newBubble);
    }

    private bool SkipBubble()
    {
        return Random.Range(0, 100) < _bubbleSkipProbability;
    }
}