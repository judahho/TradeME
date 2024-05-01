using System;
using System.Numerics;
using Raylib_cs;

namespace TMEngine.GUI;

public enum UIScreen { MainMenu, Market, Stock }
public class UI
{
    public static Vector2 Screen { get { return new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()); } }

    public Panel masterPanel = new Panel(new Rectangle(0, 0, UI.Screen.X, UI.Screen.Y));

    public UI(UIScreen screen)
    {
        switch (screen)
        {
            case UIScreen.MainMenu:
                throw new NotImplementedException();
            case UIScreen.Market:
                throw new NotImplementedException();
            case UIScreen.Stock:
                new Text("Stock", new Rectangle(), masterPanel);
                //new Graph(Program.activeStock, new Rectangle(10, 10, 200, 100), masterPanel);
                break;
            default:
                throw new Exception("Invalid UIScreen");
        }
    }

    public void Draw()
    {
        masterPanel.Draw();
    }
}
