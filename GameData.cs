using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TradeME
{
    public class GameData
    {
        [JsonIgnore (Condition = JsonIgnoreCondition.Never)]
        public List<Stock> market = new List<Stock>();
        
        #region Default Game (JSON)
        public const string defaultGame =
@"{
    ""market"" : [
        {}
}
}";
        #endregion

        #region Constructors
        public GameData()
        {
            //GameData? data = JsonSerializer.Deserialize<GameData>(defaultGame);
            //if (data == null) { throw new ArgumentException("Parameter cannot deserialize", nameof(defaultGame)); }

            market = new List<Stock>();//data.market;
        }
        public GameData(string json)
        {
            GameData? data = JsonSerializer.Deserialize<GameData>(json);
            if (data == null) { throw new ArgumentException("Parameter cannot deserialize", nameof(json)); }

            market = data.market;
        }
        #endregion

        public string GetJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
