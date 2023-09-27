using System.Collections.Generic;

namespace TradeME
{
    internal class Game
    {
        internal int[] gameSpeed = new int[] { 60, 120, 360, 720, 3600 }; // 1 real second to in game seconds
        internal List<Stock> stocks = new List<Stock>();

        internal void Update()
        {

        }
    }
}
