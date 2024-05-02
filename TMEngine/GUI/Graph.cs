using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

namespace TMEngine.GUI;

public class Graph : GUIElement
{
    /// <summary> The commodity the graph tracks. </summary>
    public Commodity commodity;
    /// <summary> Number of bars that will draw on the graph.</summary>
    public int barCount;

    public Graph(Commodity commodity, Rectangle rect, Panel? panel = null) : base(rect, Color.Gray, panel) {
        this.commodity = commodity;
        this.barCount = 40;
    }

    #region Methods

    public override void Draw()
    {
        // graph values
        int count = Math.Min(barCount, commodity.entries.Count);
        Entry rangeEntry = new(commodity.entries.GetRange(commodity.entries.Count - count, count));
        float range = Math.Max(10, rangeEntry.MaxPrice - rangeEntry.MinPrice);
        float priceY = Position.Y + ((rangeEntry.MaxPrice - commodity.Price) / range * rectangle.Height);

        // base graph
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)rectangle.Width, (int)rectangle.Height, color);
        string price = "$" + String.Format("{0:.##}", commodity.Price);
        Raylib.DrawLine((int)Position.X, (int)priceY, (int)(Position.X + rectangle.Width), (int)priceY, Color.Black);
        Raylib.DrawText(price, (int)(Position.X + rectangle.Width - Raylib.MeasureText(price, 12) - 5), (int)priceY, 12, Color.Black);
        string maxPrice = "$" + String.Format("{0:.##}", rangeEntry.MaxPrice);
        string minPrice = "$" + String.Format("{0:.##}", rangeEntry.MinPrice);
        Raylib.DrawText(maxPrice, (int)(Position.X + rectangle.Width - Raylib.MeasureText(maxPrice, 12) - 5), (int)(Position.Y + 5), 12, Color.Black);
        Raylib.DrawText(minPrice, (int)(Position.X + rectangle.Width - Raylib.MeasureText(minPrice, 12) - 5), (int)(Position.Y + rectangle.Height - 15), 12, Color.Black);

        // graph bars
        for (int i = commodity.entries.Count - count, j = 0; i < commodity.entries.Count; i++, j++) {
            DrawBar(j, commodity.entries[i], rangeEntry, range);
        }
    }
    /// <summary>
    /// Draw a bar on the graph.
    /// </summary>
    /// <param name="index"> Index of the bar to draw. This will control the position of the bar on the graph. </param>
    /// <param name="entry"> The bar's reference data. </param>
    private void DrawBar(int index, Entry entry, Entry rangeEntry, float range)
    {
        Color color = entry.Bull ? Color.Green : Color.Red;
        float rootPercent = Math.Abs(rangeEntry.MaxPrice - entry.MaxPrice) / range;
        Vector2 root = Position + new Vector2(10 + index * 10, rectangle.Height * rootPercent);
        float lineHeight = (entry.MaxPrice - entry.MinPrice) / range * rectangle.Height;
        float barTop = entry.Bull ? (entry.MaxPrice - entry.ExitPrice) / range * rectangle.Height : (entry.MaxPrice - entry.EnterPrice) / range * rectangle.Height;
        float barHeight = Math.Abs(entry.EnterPrice - entry.ExitPrice) / range * rectangle.Height;

        // draw bar
        Raylib.DrawLine((int)root.X, (int)root.Y, (int)root.X, (int)(root.Y + lineHeight), color);
        Raylib.DrawRectangle((int)(root.X - 3), (int)(root.Y + barTop), 6, (int)barHeight, color);
    }
    #endregion
}