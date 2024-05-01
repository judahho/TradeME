using Raylib_cs;

namespace TradeME;
using TMEngine;
using TMEngine.GUI;

internal static class Program
{
    #region Progeam Properties
    public const string name = "TradME";
    public const string version = "2.0.0";
    #endregion

    #region Game Properties
    public static GameData data = new GameData();
    public static UI ui = new UI(UIScreen.Stock);
    public static Commodity activeStock {
        get {
            if (data.market.Count > 0)
            {
                return data.market[0];
            } else
            {
                return new Commodity("Null Stock", "NUL", 100);
            }
        }
    }
    #endregion

    #region Methods
    public static void Init() {
        GameData data = new GameData();
        /*Commodity stock = new Commodity("Apple", "APPL", 100);
        data.market.Add(stock);
        stock = new Commodity("Microsoft", "MSFT", 100);
        data.market.Add(stock);
        stock = new Commodity("Samsung", "SAMG", 100);
        data.market.Add(stock);*/
    }
    public static void Update() {
        
    }
    #endregion

    static void Main(string[] args) {
        #region Startup
        Raylib.InitWindow(800, 480, "TradeME");
        Raylib.SetTargetFPS(60);

        Init();
        #endregion

        #region Main
        while (!Raylib.WindowShouldClose()) {
            //SECTION : Pre-Draw
            //!SECTION

            //SECTION : Start Draw
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            //!SECTION

            //SECTION : Draw
            ui.Draw();
            //!SECTION

            //SECTION : End Draw
            //Raylib.DrawFPS(0, 0);
            Raylib.EndDrawing();
            Time.UpdateTime();
            //!SECTION
        }
        #endregion
        
        #region Shutdown
        Raylib.CloseWindow();
        #endregion
    }
}