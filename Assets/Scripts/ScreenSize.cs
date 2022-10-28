using UnityEngine;

public static class ScreenSize
{
    public static Vector2 MinPosition { get; }
    public static Vector2 MaxPosition { get; }

    static ScreenSize()
    {
        MaxPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        MinPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    public static float GetScreenCorrelation()
    {
        var preferenceAspectRatio = 16.0f / 9;
        var currentAspectRatio = (float) Screen.height / Screen.width;
        var ratio = preferenceAspectRatio / currentAspectRatio;

        return ratio;
    }
}
