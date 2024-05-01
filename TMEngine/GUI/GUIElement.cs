using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

namespace TradeME.GUI;

public abstract class GUIElement
{
    public Panel? panel;
    public Rectangle rectangle;
    public Color color;

    public Vector2 Position {
        get { return panel == null ? rectangle.Position : panel.Position + rectangle.Position; }
    }

    private GUIElement(Panel? panel = null) {
        this.panel = panel;
        panel?.elements.Add(this);
        rectangle = new Rectangle();
        color = Color.White;
    }
    public GUIElement(Rectangle rectangle, Color color, Panel? parent = null) : this(parent) {
        this.rectangle = rectangle;
        this.color = color;
    }

    public abstract void Draw();
}
