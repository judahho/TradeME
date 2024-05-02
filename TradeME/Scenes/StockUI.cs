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

        this.elements.Add(new Button(()=>{
            Program.marketViewIndex--;
            if (Program.marketViewIndex < 0) { Program.marketViewIndex = Program.data.market.Count - 1; }
            Program.ui = new StockUI(Program.data.market[Program.marketViewIndex]);
        }, new Text("PREVIOUS"), new Rectangle(10, 390, 50, 50)));
        this.elements.Add(new Button(()=>{
            Program.marketViewIndex++;
            if (Program.marketViewIndex >= Program.data.market.Count) { Program.marketViewIndex = 0; }
            Program.ui = new StockUI(Program.data.market[Program.marketViewIndex]);
        }, new Text("NEXT"), new Rectangle(740, 390, 50, 50)));

        this.elements.Add(new Graph(stock, new Rectangle(10, 50, 780, 330)));
        this.elements.Add(new Text(stock.tag, 40, new Rectangle(10, 10, 10, 10)));
        this.elements.Add(new Text(stock.name, 20, new Rectangle(100, 25, 10, 10)));
    }
}
