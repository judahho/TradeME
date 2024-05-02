using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace TMEngine;

public abstract class Commodity
{
    /// <summary> Percent chance the price goes down. </summary>
    public const float bearPercent = .489f;
    public static float period = 10;

    #region Fields
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string name = "Stock";
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string tag = "STK";
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public List<Entry> entries = new List<Entry>();
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float volatility;
    #endregion

    #region Properties
    [JsonIgnore] public float Price
    {
        get
        {
            if (entries.Count == 0) { return 0; }
            return entries.Last().price;
        }
    }
    [JsonIgnore] public bool Bankrupt { get { return Price <= 0; }}
    #endregion

    #region Constructors
    public Commodity(string name, string tag, float price, float volatility = .01f)
    {
        this.name = name;
        this.tag = tag;
        this.entries.Add(new Entry(price));
        this.volatility = volatility;
    }
    public Commodity(string name, string tag, List<Entry> entries, float volatility = .01f)
    {
        this.name = name;
        this.tag = tag;
        this.entries = entries;
        this.volatility = volatility;
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
        if (Price <= 0) { return; }

        Random random = new();
        Entry entry = entries.Last();
        entry.price += (float)random.NextDouble() * (Price * volatility) * (random.NextDouble() > bearPercent ? 1 : -1) * (Time.deltaTime * 100);
        entries[^1] = entry;
        
        if (Time.unscaledTime - entry.time > period) { entries.Add(new Entry(entry.price)); }
    }
    #endregion
}
