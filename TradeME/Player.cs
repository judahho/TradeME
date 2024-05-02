using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using TMEngine;

namespace TradeME;

public class Player
{
    #region Types
    public class Property {
        [JsonIgnore] public string Name => commodity.name;
        [JsonIgnore] public string tag => commodity.tag;
        [JsonIgnore] public float Value => commodity.Price * units;

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public Commodity commodity { get; private set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public uint units;

        public Property(Commodity commodity, uint units) {
            this.commodity = commodity;
            this.units = units;
        }
    }
    #endregion

    #region Fields
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float money;
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public List<Property> properties;
    #endregion

    #region  Properties
    [JsonIgnore] public float GrossWorth => Worth + money;
    [JsonIgnore] public float Worth {
        get {
            float worth = 0;
            foreach (Property property in properties) { worth += property.Value; }
            return worth;
        }
    }
    #endregion

    #region Constructor
    public Player(float money) {
        this.money = money;
        this.properties = [];
    }
    #endregion
}
