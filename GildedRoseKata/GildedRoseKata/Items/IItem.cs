using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Items
{
    public interface IItem
    {
        String Name { get; set; }
        Int32 SellIn { get; set; }
        Int32 Quality { get; set; }
        void Update();
    }
}
