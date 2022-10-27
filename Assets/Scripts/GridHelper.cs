using UnityEngine;

public static class GridHelper
{
        public static (int,int) GetBubbleIndex(Vector3 position, Vector3 size)
        {
                var distanceToScreenTop = ScreenSize.MaxPosition.y - position.y;
                var distanceToScreenLeft = position.x - ScreenSize.MinPosition.x;
                var originalSize = size.y / ScreenSize.GetScreenCorrelation();
                var countRowsBefore = distanceToScreenTop / originalSize;
                var countColumnsBefore = distanceToScreenLeft / originalSize;
                var snapRowIndex = (int) countRowsBefore;
                var snapColumnIndex = (int) countColumnsBefore;

                return (snapRowIndex, snapColumnIndex);
        }
}