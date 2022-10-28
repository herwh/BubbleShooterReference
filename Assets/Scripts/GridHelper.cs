using UnityEngine;

public static class GridHelper
{
    public static int Columns { get; set; }
    public static int MaxRows { get; set; }

    public static (int, int) GetBubbleIndex(Vector3 position, Vector3 size)
    {
        var distanceToScreenTop = ScreenSize.MaxPosition.y - position.y;

        var originalSize = size / ScreenSize.GetScreenCorrelation();
        var countRowsBefore = distanceToScreenTop / originalSize.y;
        var snapRowIndex = (int) countRowsBefore;
        var distanceToScreenLeft = Mathf.Abs(ScreenSize.MinPosition.x - position.x);
        var maxColumnLimit = Columns - 1;

        if (IsOdd(snapRowIndex))
        {
            distanceToScreenLeft -= size.x * 0.5f;
            maxColumnLimit++;
        }

        var countColumnsBefore = distanceToScreenLeft / originalSize.x;
        var snapColumnIndex = (int) countColumnsBefore;
        snapRowIndex = Mathf.Clamp(snapRowIndex, 0, MaxRows);
        snapColumnIndex = Mathf.Clamp(snapColumnIndex, 0, maxColumnLimit);

        return (snapRowIndex, snapColumnIndex);
    }

    public static Vector2 GetCorrectBubblePosition(int row, int column, Vector3 size)
    {
        var originalSize = size / ScreenSize.GetScreenCorrelation();
        var halfBubbleWidth = originalSize.x * 0.5f;
        var rowPosition = ScreenSize.MaxPosition.y - originalSize.y * row - originalSize.y * 0.5f;
        var columnPosition = ScreenSize.MinPosition.x + originalSize.x * column + halfBubbleWidth;

        if (IsOdd(row))
        {
            columnPosition += halfBubbleWidth;
        }

        return new Vector2(columnPosition, rowPosition);
    }

    public static bool IsOdd(int row)
    {
        return row % 2 != 0;
    }
}