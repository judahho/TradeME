using System.Collections.Generic;
using Raylib_cs;
using TMEngine;
using TMEngine.GUI;

namespace TradeME;

internal static class Program
{
    #region Constant Properties
    public const string name = "TradME";
    public const string version = "2.0.0";
    #endregion

    #region Static Fields
    public static GameData data = new();
    public static UI ui = new();
    #endregion

    static void Main(string[] args) {
        #region Startup
        Raylib.InitWindow(800, 480, "TradeME");
        Raylib.SetTargetFPS(60);

        Stock gold = new Stock("Some Software Company Co.", "SSC", 40);
        data.market.Add(gold);

        ui = new StockUI(gold);
        #endregion

        #region Main
        while (!Raylib.WindowShouldClose()) {
            //SECTION : Pre-Draw
            Time.UpdateTime();

            foreach (Commodity commodity in data.market) {
                commodity.Tick();
            }
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
            //!SECTION
        }
        #endregion
        
        #region Shutdown
        Raylib.CloseWindow();
        #endregion
    }
}