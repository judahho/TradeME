using Raylib_cs;

namespace TradeME
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 480, "TradeME");
            Game game = new Game();

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                game.Update();

                Raylib.DrawFPS(0, 0);
                Time.UpdateTime();
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}