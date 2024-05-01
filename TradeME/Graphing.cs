using Raylib_cs;
using System.Numerics;

namespace TradeME;

public class Graph : Panel
{
    public Stock stock;

    private new List<Text> texts;
    private new List<Button> buttons;
    private new List<Graph> graphs;
    private new List<Panel> panels;

    public Graph(Panel parent, Stock stock, Rectangle rect) : base(parent, rect)
    {
        this.stock = stock;
        this.rectangle = rect;

        this.texts = new List<Text>();
        this.buttons = new List<Button>();
        this.graphs = new List<Graph>();
        this.panels = new List<Panel>();
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)rectangle.Width, (int)rectangle.Height, color);
    }
}
public struct Bar
{
    public void Draw(Graph graph, Entry entry)
    {
        Color color = (entry.bull) ? Color.Red : Color.Green;
        Vector2 root = graph.position;
        Raylib.DrawLine((int)root.X, (int)root.Y, (int)root.X, (int)(root.Y + entry.minPrice), color);
        Raylib.DrawRectangle((int)(root.X - 3), (int)root.Y, 6, (int)entry.exitPrice, color);
    }
}
