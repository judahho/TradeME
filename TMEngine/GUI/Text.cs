using Raylib_cs;

namespace TMEngine.GUI;

public class Text : GUIElement
{
    public string text;
    public int fontSize;

    public Text (string text, int fontSize, Rectangle rect, Color color, Panel? panel = null) : base(rect, color, panel)
    {
        this.text = text;
        this.fontSize = fontSize;
    }
    public Text(string text, Rectangle rect, Color color, Panel? panel = null) : this(text, 10, rect, color, panel) {}
    public Text(string text, int fontSize, Rectangle rect, Panel? panel = null) : this(text, fontSize, rect, Color.Black, panel) {}
    public Text(string text, Rectangle rect, Panel? panel = null) : this(text, 10, rect, Color.Black, panel) {}

    public override void Draw()
    {
        Raylib.DrawText(text, (int)Position.X, (int)Position.Y, fontSize, color);
    }
}