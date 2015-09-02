using GildedRoseKata.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Strategies
{
    public interface IItemUpdateStrategy
    {
        void UpdateItem(IItem item);
    }
}
