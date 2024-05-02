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
            if (element is Button && IsMouseHover(element)) {
                if (Raylib.IsMouseButtonPressed(MouseButton.Left)) {
                    Button? button = element as Button;
                    button?.action?.Invoke();
                }
                // TODO: hover color change
            }
        }
    }

    #region Private Methods
    private static bool IsMouseHover(GUIElement element) {
        Vector2 mousePos = Raylib.GetMousePosition();
        if (mousePos.X < element.Position.X) { return false; }
        else if (mousePos.X > element.Position.X + element.rectangle.Width) { return false; }
        else if (mousePos.Y < element.Position.Y) { return false; }
        else if (mousePos.Y > element.Position.Y + element.rectangle.Height) { return false; }
        return true;
    }
    #endregion
}
