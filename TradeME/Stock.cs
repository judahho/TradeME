using System;
using System.Collections.Generic;
using Raylib_cs;
using TMEngine;
namespace TradeME;

public class Stock : Commodity
{
    public Stock(string name, string tag, float price) : base(name, tag, price) {}
    public Stock(string name, string tag, List<Entry> entries) : base(name, tag, entries) {}
}
