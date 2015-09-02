using GildedRoseKata.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Strategies
{
    public class StupidStrategy : IItemUpdateStrategy
    {
        public void UpdateItem(IItem item)
        {
            item.Quality = 0;
            item.SellIn = 0;
        }
    }
}
