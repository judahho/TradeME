using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

namespace TMEngine.GUI;

public class UI {
    public static Vector2 Screen { get { return new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()); } }

    public List<GUIElement> elements;

    public UI() {
        elements = [];
    }

    public void Draw() {
        foreach (GUIElement element in elements) {
            element.Draw();
        }
    }
}
