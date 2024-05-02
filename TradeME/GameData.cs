using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using TMEngine;

namespace TradeME;

public class GameData
{
    [JsonIgnore (Condition = JsonIgnoreCondition.Never)]
    public List<Commodity> market = new List<Commodity>();
    
    #region Default Game (JSON)
    public const string defaultGame =
@"{
    ""market"" : [
        {
            ""name"" : ""Gold"",
            ""tag"" : ""GLD"",
            ""entries"" : {}
        },
        {
            ""name"" : ""Silver"",
            ""tag"" : ""SLV"",
            ""entries"" : {}
        },
        {
            ""name"" : ""Oil"",
            ""tag"" : ""OIL"",
            ""entries"" : {}
        },
        {
            ""name"" : ""Food"",
            ""tag"" : ""FDD"",
            ""entries"" : {}
        }
    }
}";
    #endregion

    #region Constructors
    public GameData()
    {
        //GameData? data = JsonSerializer.Deserialize<GameData>(defaultGame);
        //if (data == null) { throw new ArgumentException("Parameter cannot deserialize", nameof(defaultGame)); }

        market = new List<Commodity>();//data.market;
    }
    public GameData(string json)
    {
        GameData? data = JsonSerializer.Deserialize<GameData>(json);
        if (data == null) { throw new ArgumentException("Parameter cannot deserialize", nameof(json)); }

        market = data.market;
    }
    #endregion

    #region Methods
    public string GetJson()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(this, options);
    }
    #endregion
}
