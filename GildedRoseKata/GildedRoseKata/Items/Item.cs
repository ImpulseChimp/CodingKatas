using System;

namespace GildedRoseKata.Items
{
    public abstract class Item
    {
        public String Name { get; set; }
        public Int32 SellIn { get; set; }
        public Int32 Quality { get; set; }
        public abstract void Update();

        public Item(String name, Int32 sellIn, Int32 quality)
        {
            this.Name = name;
            this.SellIn = sellIn;
            this.Quality = quality;
        }

        protected void NegativeSellIn()
        {
            if (SellIn < 0)
                IncreaseQualityByOne();
        }
        
        protected void DecreaseSellIn()
        {
            SellIn -= 1;
        }

        protected void DecreaseQualityByOne()
        {
            if (Quality != 0)
                Quality -= 1;
        }

        protected Boolean HasQuality()
        {
            return Quality > 0;
        }

        protected void IncreaseQualityByOne()
        {
            if (Quality < 50)
                Quality += 1;
        }

        protected void NegativeSellInWithQuality()
        {
            if (SellIn < 0 && HasQuality())
                DecreaseQualityByOne();
        }

        public override Boolean Equals(Object obj)
        {
            var item = obj as Item;
            if (obj == null)
                return false;
            return Name == item.Name && SellIn == item.SellIn && Quality == item.Quality;
        }
    }
}
