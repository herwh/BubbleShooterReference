using UnityEngine;

public static class ScreenSize
{
    public static float GetScreenCorrelation()
    {
        var preferenceAspectRatio = 16.0f / 9;
        var curentAspectRatio = (float) Screen.height / Screen.width;
        var ratio = preferenceAspectRatio / curentAspectRatio;

        return ratio;
    }
}
