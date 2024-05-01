using Raylib_cs;

namespace TMEngine;

public class Time
{
    public static float time {  get; private set; }
    public static float unscaledTime
    {
        get { return (float)Raylib.GetTime(); }
    }
    public static float deltaTime
    {
        get { return unscaledDeltaTime * timeScale; }
    }
    public static float unscaledDeltaTime
    {
        get { return Raylib.GetFrameTime(); }
    }

    public static float timeScale = 1f;

    public static void UpdateTime()
    {
        time += deltaTime;
    }
}
