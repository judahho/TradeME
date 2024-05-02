using System;
using System.Numerics;
using Raylib_cs;
using TMEngine;
using TMEngine.GUI;

namespace TradeME;

public class StockUI : UI
{
    public Stock stock;

    public StockUI(Stock stock) {
        this.stock = stock;

        // cycle stocks
        this.elements.Add(new Button(()=>{
            Program.marketViewIndex--;
            if (Program.marketViewIndex < 0) { Program.marketViewIndex = Program.data.market.Count - 1; }
            Program.ui = new StockUI(Program.data.market[Program.marketViewIndex]);
        }, new Text("PREVIOUS"), new Rectangle(10, 390, 100, 50)));
        this.elements.Add(new Button(()=>{
            Program.marketViewIndex++;
            if (Program.marketViewIndex >= Program.data.market.Count) { Program.marketViewIndex = 0; }
            Program.ui = new StockUI(Program.data.market[Program.marketViewIndex]);
        }, new Text("NEXT"), new Rectangle(690, 390, 100, 50)));

        // Stock
        this.elements.Add(new Graph(stock, new Rectangle(10, 50, 600, 330)));
        this.elements.Add(new Text(stock.tag, 40, new Rectangle(10, 10, 10, 10)));
        this.elements.Add(new Text(stock.name, 20, new Rectangle(100, 25, 10, 10)));

        // player info
        this.elements.Add(new LiveText(()=>{
            return String.Format("GROSS: {0:.##}", Program.data.player.GrossWorth);
        }, 20, new Rectangle(620, 10, 50, 50)));
        this.elements.Add(new LiveText(()=>{
            return String.Format("Money: {0:.##}", Program.data.player.money);
        }, 15, new Rectangle(635, 30, 50, 50)));
        this.elements.Add(new LiveText(()=>{
            return String.Format("Worth: {0:.##}", Program.data.player.Worth);
        }, 15, new Rectangle(635, 45, 50, 50)));

        // buy/sell
        this.elements.Add(new LiveText(()=>{
            Player.Property? property = Program.data.player.properties.Find(property => property.commodity == Program.data.market[Program.marketViewIndex]);
            uint units = property?.units ?? 0;
            return $"Units : {units}";
        }, 15, new Rectangle(620, 250, 170, 50)));
        this.elements.Add(new Button(()=>{
            Program.Buy(Program.data.market[Program.marketViewIndex], 1);
        }, new Text("BUY"), new Rectangle(620, 270, 170, 50)));
        this.elements.Add(new Button(()=>{
            Program.Sell(Program.data.market[Program.marketViewIndex], 1);
        }, new Text("SELL"), new Rectangle(620, 330, 170, 50)));
    }
}
