using System;

namespace GildedRoseKata.Items
{
    public class BackstagePass : Item
    {
        public BackstagePass(String name, Int32 sellIn, Int32 quality) : base(name, sellIn, quality)
        {}

        public override void Update()
        {
            IncreaseQualityByOne();

            if (SellIn < 11)
            {
                IncreaseQualityByOne();
                if (SellIn < 6)
                    IncreaseQualityByOne();
            }

            DecreaseSellIn();

            if (SellIn < 0)
                Quality = 0;
        }
    }
}
