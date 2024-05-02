using System;
using System.Numerics;
using Raylib_cs;
using TMEngine.GUI;

namespace TradeME;

public class StockUI : UI
{
    public Stock stock;

    public StockUI(Stock stock) {
        this.stock = stock;

        this.elements.Add(new Graph(stock, new Rectangle(10, 50, 600, 300)));
        this.elements.Add(new Text(stock.tag, 40, new Rectangle(10, 10, 10, 10)));
        this.elements.Add(new Text(stock.name, 20, new Rectangle(100, 25, 10, 10)));
    }
}
