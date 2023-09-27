using Raylib_cs;

namespace TradeME
{
    public class Time
    {
        public static float time {  get; private set; }
        public static float unscaledTime
        {
            get { return (float)Raylib.GetTime(); }
            private set { }
        }
        public static float deltaTime
        {
            get { return unscaledDeltaTime * timeScale; }
            private set { }
        }
        public static float unscaledDeltaTime
        {
            get { return Raylib.GetFrameTime(); }
            private set { }
        }

        public static float timeScale = 1f;

        public static void UpdateTime()
        {
            time += deltaTime;
        }
    }
}
