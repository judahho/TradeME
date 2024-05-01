using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TMEngine;

public class Commodity
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string name = "Stock";
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string tag = "STK";
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public List<Entry> entries = new List<Entry>();

    [JsonIgnore] public float price
    {
        get
        {
            if (entries.Count == 0) { return 0; }
            return entries.Last().price;
        }
    }

    // divides the entries to 24 per day and returns the most recent da
    [JsonIgnore] public Entry[] today
    {
        get
        {
            List<Entry> list = new List<Entry>();
            int z = entries.Count - ((entries.Count % 24 == 0) ? 24 : (entries.Count % 24));
            for (int i = z - 1; i < entries.Count; i++) { list.Add(entries[i]); }
            return list.ToArray();
        }
    }
    [JsonIgnore] public Entry[] week = new Entry[7];
    [JsonIgnore] public Entry[] month = new Entry[28];

    #region Constructors
    public Commodity(string name, string tag, float price)
    {
        this.name = name;
        this.tag = tag;
        this.entries.Add(new Entry(price));
    }
    public Commodity(string name, string tag, List<Entry> e)
    {
        this.name = name;
        this.tag = tag;
        this.entries = e;
    }
    #endregion

    #region Operators
    [JsonIgnore] public Entry this[int index] => entries[entries.Count - index - 1];

    public static Commodity operator +(Commodity lhs, Entry rhs)
    {
        lhs.entries.Add(rhs);
        return lhs;
    }
    public static Commodity operator +(Entry lhs, Commodity rhs) { return rhs + lhs; }
    #endregion
}
