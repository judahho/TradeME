using System.Numerics;
using Raylib_cs;

namespace TMEngine.GUI;

public class Graph : GUIElement
{
    #region Types
    public struct Bar {
        public void Draw(Graph graph, Entry entry)
        {
            Color color = entry.bull ? Color.Red : Color.Green;
            Vector2 root = graph.Position;
            Raylib.DrawLine((int)root.X, (int)root.Y, (int)root.X, (int)(root.Y + entry.minPrice), color);
            Raylib.DrawRectangle((int)(root.X - 3), (int)root.Y, 6, (int)entry.exitPrice, color);
        }
    }
    #endregion

    public Commodity stock;

    public Graph(Commodity stock, Rectangle rect, Panel? panel = null) : base(rect, Color.Gray, panel) {
        this.stock = stock;
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)rectangle.Width, (int)rectangle.Height, color);
        // TODO: draw stock graph
    }
}