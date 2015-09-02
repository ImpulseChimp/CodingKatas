using System;

namespace GildedRoseKata.Items
{
    public class ManaCake : Item
    {
        public ManaCake(String name, Int32 sellIn, Int32 quality) : base(name, sellIn, quality)
        {}

        public override void Update()
        {
            DecreaseQualityByOne();
            DecreaseSellIn();
            NegativeSellInWithQuality();
        }
    }
}
