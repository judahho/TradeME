using Raylib_cs;

namespace TMEngine.GUI;

public class Panel : GUIElement
{
    public List<GUIElement> elements;

    public Panel(Rectangle rect, Color color, Panel? parent = null) : base(rect, color, parent) {
        this.elements = new List<GUIElement>();
    }
    public Panel(Rectangle rect, Panel? parent = null) : base(rect, Color.White, parent) {
        this.elements = new List<GUIElement>();
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)rectangle.Width, (int)rectangle.Height, color);
        foreach (GUIElement element in elements) { element.Draw(); }
    }
}

