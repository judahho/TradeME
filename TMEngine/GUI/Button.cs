using System;
using System.Numerics;
using Raylib_cs;

namespace TMEngine.GUI;

public class Button : GUIElement {
    public Text? text;
    public Action action;

    public Button(Action action, Text? text, Rectangle rect, Color color, Panel? panel = null) : base (rect, color, panel) {
        this.action = action;
        this.text = text;
        if (text != null) { text.rectangle = rect; }
    }
    public Button(Action action, Text? text, Rectangle rect, Panel? panel = null) : this(action, text, rect, Color.Gray, panel) {}
    public Button(Action action, Rectangle rect, Color color, Panel? panel = null) : this(action, null, rect, color, panel) {}
    public Button(Action action, Rectangle rect, Panel? panel = null) : this(action, null, rect, Color.Gray, panel) {}

    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)rectangle.Width, (int)rectangle.Height, color);
        if (text != null) {
            Font font = Raylib.GetFontDefault();
            Vector2 textSize = Raylib.MeasureTextEx(font, text.text, text.fontSize, 1);
            text.rectangle = rectangle;
            text.rectangle.X = rectangle.X + (rectangle.Width * .5f - textSize.X * .5f);
            text.rectangle.Y = rectangle.Y + (rectangle.Height * .5f - textSize.Y * .5f);
            text.Draw();
        }
    }
}