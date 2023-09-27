using System.Collections.Generic;

namespace TradeME
{
    internal class Stock
    {
        internal string name = "Stock";
        internal string tag = "STK";
        internal List<Entry> entries = new List<Entry>();

        internal Entry[] day = new Entry[24];
        internal Entry[] week = new Entry[7];
        internal Entry[] month = new Entry[28];
    }
}
