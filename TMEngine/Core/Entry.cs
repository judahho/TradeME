using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TMEngine;

public struct Entry
{
    #region Fields
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float EnterPrice { get; private set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float ExitPrice { get; private set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float MaxPrice { get; private set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float MinPrice { get; private set; }
    [JsonIgnore] public float time;
    #endregion 

    #region Properties
    [JsonIgnore] public float price
    {
        get { return ExitPrice; }
        set
        {
            ExitPrice = value;
            if (ExitPrice < MinPrice) { MinPrice = ExitPrice; }
            if (ExitPrice > MaxPrice) { MaxPrice = ExitPrice; }
        }
    }
    [JsonIgnore] public bool Bull { get { return ExitPrice >= EnterPrice; } }
    [JsonIgnore] public bool Bear { get { return !Bull; } }
    #endregion

    #region Constructors
    public Entry(float price, float enterPrice, float max, float min) {
        this.EnterPrice = enterPrice;
        this.ExitPrice = price;
        this.MaxPrice = max;
        this.MinPrice = min;
        this.time = Time.time;
    }
    public Entry(float price) : this(price, price, price, price) { }

    public Entry(Entry[] entries) : this(entries[0].ExitPrice, entries[0].EnterPrice, entries[0].MaxPrice, entries[0].MinPrice)
    {
        for (int i = 1; i < entries.Length; i++) { 
            this.price = entries[i].MaxPrice;
            this.price = entries[i].MinPrice;
            this.price = entries[i].price; 
        }
    }
    public Entry(List<Entry> entries) : this(entries.ToArray()) {}
    #endregion
}
