using System;

namespace GildedRoseKata.Items
{
    public class DexterityVest : Item
    {
        public DexterityVest(String name, Int32 sellIn, Int32 quality) : base(name, sellIn, quality)
        {}

        public override void Update()
        {
            DecreaseQualityByOne();
            DecreaseSellIn();

            if (SellIn < 0 && HasQuality())
                DecreaseQualityByOne();
        }
    }
}
