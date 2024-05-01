using Raylib_cs;

namespace TradeME.GUI;

public class Button : GUIElement {
    public Text? text;
    public Action action;

    public Button(Text? text, Action action, Rectangle rect, Color color, Panel? panel = null) : base (rect, color, panel) {
        this.text = text;
        this.action = action;
    }
    public Button(Text? text, Action action, Rectangle rect, Panel? panel = null) : this(text, action, rect, Color.Gray, panel) {}
    public Button(Action action, Rectangle rect, Color color, Panel? panel = null) : this(null, action, rect, color, panel) {}
    public Button(Action action, Rectangle rect, Panel? panel = null) : this(null, action, rect, Color.Gray, panel) {}

    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)rectangle.Width, (int)rectangle.Height, color);
    }
}