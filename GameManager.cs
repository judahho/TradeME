using System.Collections.Generic;

namespace TradeME
{
    public class GameManager
    {
        public GameData data = new GameData();
        public UI ui = new UI(UIScreen.Stock);

        public Stock activeStock { get
            {
                if (data.market.Count > 0)
                {
                    return data.market[0];
                } else
                {
                    return new Stock("Null Stock", "NUL", 100);
                }
            } }

        public void Update()
        {

        }

        public void Init()
        {
            GameData data = new GameData();
            Stock stock = new Stock("Apple", "APPL", 100);
            data.market.Add(stock);
            stock = new Stock("Microsoft", "MSFT", 100);
            data.market.Add(stock);
            stock = new Stock("Samsung", "SAMG", 100);
            data.market.Add(stock);
        }
    }
}
