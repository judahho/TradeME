using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace TMEngine;

public abstract class Commodity
{
    public static float period = 10;
    #region Fields
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string name = "Stock";
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string tag = "STK";
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public List<Entry> entries = new List<Entry>();
    #endregion

    #region Properties
    [JsonIgnore] public float price
    {
        get
        {
            if (entries.Count == 0) { return 0; }
            return entries.Last().price;
        }
    }
    /// <summary> Divides the entries to 24 per day and returns the most recent day. </summary>
    [JsonIgnore] public Entry[] Today
    {
        get
        {
            List<Entry> list = new List<Entry>();
            int z = entries.Count - ((entries.Count % 24 == 0) ? 24 : (entries.Count % 24));
            for (int i = z - 1; i < entries.Count; i++) { list.Add(entries[i]); }
            return list.ToArray();
        }
    }
    [JsonIgnore] public Entry[] Week { get { return new Entry[7]; } }
    [JsonIgnore] public Entry[] Month { get { return new Entry[28]; } }
    #endregion

    #region Constructors
    public Commodity(string name, string tag, float price)
    {
        this.name = name;
        this.tag = tag;
        this.entries.Add(new Entry(price));
    }
    public Commodity(string name, string tag, List<Entry> entries)
    {
        this.name = name;
        this.tag = tag;
        this.entries = entries;
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

    #region Methods
    public virtual void Tick() {
        Random random = new();
        Entry entry = entries.Last();
        entry.price += (float)random.NextDouble()  * Time.deltaTime * 100 * (random.NextDouble() > .5 ? 1 : -1);
        entries[^1] = entry;
        
        if (Time.unscaledTime - entry.time > period) { entries.Add(new Entry(entry.price)); }
    }
    #endregion
}
