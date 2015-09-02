using System.Collections.Generic;
using GildedRoseKata.Items;

namespace GildedRoseKata
{
    public class ItemManager
    {
        public static IList<Item> Items;

        public static void InitializeInventory()
        {
            Items = new List<Item>()
            {
                new DexterityVest("+5 Dexterity Vest", 10, 20),
                new AgedBrie("Aged Brie", 2, 0),
                new MongooseElixir("Elixir of the Mongoose", 5, 7),
                new Sulfuras("Sulfuras, Hand of Ragnaros", 0, 80),
                new BackstagePass("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                new ManaCake("Conjured Mana Cake", 3, 6)
            };
        }

        public static void UpdateQuality()
        {
            foreach (var item in Items)
                item.Update();
        }
    }
}
