using System;

namespace GildedRoseKata.Items
{
    public class AgedBrie : Item
    {
        public AgedBrie(String name, Int32 sellIn, Int32 quality) : base(name, sellIn, quality)
        {}

        public override void Update()
        {
            IncreaseQualityByOne();
            DecreaseSellIn();
            NegativeSellIn();
        }
    }
}
