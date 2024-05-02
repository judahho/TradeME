using System;
using System.Numerics;
using Raylib_cs;

namespace TMEngine.GUI;

public class Graph : GUIElement
{
    public Commodity commodity;

    public Graph(Commodity commodity, Rectangle rect, Panel? panel = null) : base(rect, Color.Gray, panel) {
        this.commodity = commodity;
    }

    #region Methods

    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)rectangle.Width, (int)rectangle.Height, color);
        Raylib.DrawLine((int)Position.X, (int)(Position.Y + 150 - commodity.price), (int)(Position.X + rectangle.Width), (int)(Position.Y + 150 - commodity.price), Color.Black);
        string price = "$" + String.Format("{0:.##}", commodity.price);
        Raylib.DrawText(price, (int)(Position.X + rectangle.Width - Raylib.MeasureText(price, 12) - 5), (int)(Position.Y + 150 - commodity.price), 12, Color.Black);

        // TODO: draw stock graph
        for (int i = commodity.entries.Count - Math.Min(40, commodity.entries.Count), j = 0; i < commodity.entries.Count; i++, j++) {
            DrawBar(j, commodity.entries[i]);
        }
    }
    public void DrawBar(int count, Entry entry)
    {
        Color color = entry.Bull ? Color.Green : Color.Red;
        Vector2 root = Position + new Vector2(10 + count * 10, 150 - entry.MaxPrice);
        float lineHeight = Math.Abs(entry.MaxPrice - entry.MinPrice);
        float barTop = entry.Bull ? root.Y + entry.MaxPrice - entry.ExitPrice : root.Y + entry.MaxPrice - entry.EnterPrice;
        float barHeight = Math.Abs(entry.EnterPrice - entry.ExitPrice);
        Raylib.DrawLine((int)root.X, (int)root.Y, (int)root.X, (int)(root.Y + lineHeight), color);
        Raylib.DrawRectangle((int)(root.X - 3), (int)barTop, 6, (int)barHeight, color);
    }
    #endregion
}