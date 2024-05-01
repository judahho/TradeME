using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace TradeME;

public struct Entry
{
    [JsonIgnore] public float price
    {
        get { return exitPrice; }
        set
        {
            exitPrice = value;
            if (exitPrice < minPrice) { minPrice = exitPrice; }
            else if (exitPrice > maxPrice) { maxPrice = exitPrice; }
        }
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float enterPrice {  get; private set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float exitPrice { get; private set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float maxPrice { get; private set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float minPrice { get; private set; }
    [JsonIgnore] public bool bull { get { return (exitPrice > enterPrice) ? true : false; } }
    [JsonIgnore] public bool bear { get { return !bull; } }

    public Entry(float price)
    {
        this.enterPrice = price;
        this.exitPrice = price;
        this.maxPrice = price;
        this.minPrice = price;
    }
    public Entry(Entry[] entries)
    {
        this.enterPrice = entries[0].enterPrice;
        this.exitPrice = entries[0].exitPrice;
        this.maxPrice = entries[0].maxPrice;
        this.minPrice = entries[0].minPrice;
        for (int i = 1; i < entries.Length; i++) { this.price = entries[i].price; }
    }
}
