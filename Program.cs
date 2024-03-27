using Raylib_cs;

namespace TradeME
{
    internal class Program
    {
        public static GameManager? game;

        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 480, "TradeME");
            Raylib.SetTargetFPS(60);
            game = new GameManager();
            game.Init();
            //game.CreateStocks();

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                // Update order
                game.Update();
                game.ui.Update();

                //Raylib.DrawFPS(0, 0);
                Raylib.EndDrawing();
                Time.UpdateTime();
            }
            Raylib.CloseWindow();
        }
    }
}