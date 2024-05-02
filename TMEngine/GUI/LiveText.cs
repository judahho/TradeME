using System;
using Raylib_cs;
using TMEngine.GUI;

namespace TMEngine;

public class LiveText : Text
{
    public delegate string Live();
    public Live live;

    public LiveText(Live live, int fontSize, Rectangle rect, Color color, Panel? panel = null) : base("Action Text", fontSize, rect, color, panel)
    {
        this.live = live;
    }
    
    public LiveText(Live live, Rectangle rect, Color color, Panel? panel = null) : this(live, 10, rect, color, panel) {}
    public LiveText(Live live, int fontSize, Rectangle rect, Panel? panel = null) : this(live, fontSize, rect, Color.Black, panel) {}
    public LiveText(Live live, Rectangle rect, Panel? panel = null) : this(live, 10, rect, Color.Black, panel) {}
    public LiveText(Live live, int fontSize, Color color, Panel? panel = null) : this(live, fontSize, new Rectangle(), color, panel) {}
    public LiveText(Live live, int fontSize, Panel? panel = null) : this(live, fontSize, new Rectangle(), Color.Black, panel) {}
    public LiveText(Live live, Panel? panel = null) : this(live, 10, new Rectangle(), Color.Black, panel) {}

    public override void Draw()
    {
        text = live.Invoke();
        base.Draw();
    }
}
