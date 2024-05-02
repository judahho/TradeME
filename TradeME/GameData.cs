using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using TMEngine;

namespace TradeME;

public class GameData
{
    [JsonIgnore (Condition = JsonIgnoreCondition.Never)]
    public Player player;
    [JsonIgnore (Condition = JsonIgnoreCondition.Never)]
    public List<Stock> market = [];
    
    #region Default Game (JSON)
    public const string defaultGame =
@"{
    ""player"" : {
        ""money"" : 1000,
        ""properties"" : []
    },
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
        //if (data == null) { throw new ArgumentException("Parameter cannot deserialize", nameof(defaultGame));
        this.player = new Player(1000); //data.player;
        this.market = [];//data.market;
    }
    public GameData(string json)
    {
        GameData? data = JsonSerializer.Deserialize<GameData>(json) ?? throw new ArgumentException("Parameter cannot deserialize", nameof(json));
        this.player = data.player;
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
