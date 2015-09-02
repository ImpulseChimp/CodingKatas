using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRoseKata;
using System.Collections.Generic;
using System.Linq;
using GildedRoseKata.Items;

namespace GildedRoseKataTests
{
    [TestClass]
    public class GildedRoseKataTests
    {
        private DexterityVest dexterityVest;
        private AgedBrie agedBri;
        private MongooseElixir elixirOfMongoose;
        private Sulfuras handOfRagnaros;
        private BackstagePass backstagePass;
        private ManaCake manaCake;

        [TestInitialize]
        public void Initialize()
        {
            ItemManager.InitializeInventory();

            dexterityVest = new DexterityVest("+5 Dexterity Vest", 10, 20);
            agedBri = new AgedBrie("Aged Brie", 2, 0);
            elixirOfMongoose = new MongooseElixir("Elixir of the Mongoose", 5, 7);
            handOfRagnaros = new Sulfuras("Sulfuras, Hand of Ragnaros", 0, 80);
            backstagePass = new BackstagePass("Backstage passes to a TAFKAL80ETC concert", 15, 20);
            manaCake = new ManaCake("Conjured Mana Cake", 3, 6);
        }

        [TestMethod]
        public void InventoryInitializedCorrectly()
        {
            var inventoryList = ItemManager.Items;

            Assert.AreEqual(6, ItemManager.Items.Count());
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(dexterityVest)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(agedBri)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(elixirOfMongoose)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(handOfRagnaros)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(backstagePass)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(manaCake)));
        }

        [TestMethod]
        public void SingleRunOfUpdateQuantity()
        {
            ItemManager.UpdateQuality();

            dexterityVest = new DexterityVest("+5 Dexterity Vest", 9, 19);
            agedBri = new AgedBrie("Aged Brie", 1, 1);
            elixirOfMongoose = new MongooseElixir("Elixir of the Mongoose", 4, 6);
            handOfRagnaros = new Sulfuras("Sulfuras, Hand of Ragnaros", 0, 80);
            backstagePass = new BackstagePass("Backstage passes to a TAFKAL80ETC concert", 14, 21);
            manaCake = new ManaCake("Conjured Mana Cake", 2, 5);

            Assert.AreEqual(6, ItemManager.Items.Count());
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(dexterityVest)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(agedBri)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(elixirOfMongoose)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(handOfRagnaros)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(backstagePass)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(manaCake)));
        }

        [TestMethod]
        public void TwoRunsOfUpdateQuantity()
        {
            ItemManager.InitializeInventory();
            updateQuantityNTimes(2);

            dexterityVest = new DexterityVest("+5 Dexterity Vest", 8, 18);
            agedBri = new AgedBrie("Aged Brie", 0, 2);
            elixirOfMongoose = new MongooseElixir("Elixir of the Mongoose", 3, 5);
            handOfRagnaros = new Sulfuras("Sulfuras, Hand of Ragnaros", 0, 80);
            backstagePass = new BackstagePass("Backstage passes to a TAFKAL80ETC concert", 13, 22);
            manaCake = new ManaCake("Conjured Mana Cake", 1, 4);

            Assert.AreEqual(6, ItemManager.Items.Count());
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(dexterityVest)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(agedBri)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(elixirOfMongoose)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(handOfRagnaros)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(backstagePass)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(manaCake)));
        }

        [TestMethod]
        public void ThreeRunsOfUpdateQuantity()
        {
            ItemManager.InitializeInventory();
            updateQuantityNTimes(3);

            dexterityVest = new DexterityVest("+5 Dexterity Vest", 7, 17);
            agedBri = new AgedBrie("Aged Brie", -1, 4);
            elixirOfMongoose = new MongooseElixir("Elixir of the Mongoose", 2, 4);
            handOfRagnaros = new Sulfuras("Sulfuras, Hand of Ragnaros", 0, 80);
            backstagePass = new BackstagePass("Backstage passes to a TAFKAL80ETC concert", 12, 23);
            manaCake = new ManaCake("Conjured Mana Cake", 0, 3);

            Assert.AreEqual(6, ItemManager.Items.Count());
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(dexterityVest)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(agedBri)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(elixirOfMongoose)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(handOfRagnaros)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(backstagePass)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(manaCake)));
        }

        [TestMethod]
        public void RunUpdateQuantityUntilSellInIsZero()
        {
            ItemManager.InitializeInventory();
            updateQuantityNTimes(4);

            dexterityVest = new DexterityVest("+5 Dexterity Vest", 6, 16);
            agedBri = new AgedBrie("Aged Brie", -2, 6);
            elixirOfMongoose = new MongooseElixir("Elixir of the Mongoose", 1, 3);
            handOfRagnaros = new Sulfuras("Sulfuras, Hand of Ragnaros", 0, 80);
            backstagePass = new BackstagePass("Backstage passes to a TAFKAL80ETC concert", 11, 24);
            manaCake = new ManaCake("Conjured Mana Cake", -1, 1);

            Assert.AreEqual(6, ItemManager.Items.Count());
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(dexterityVest)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(agedBri)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(elixirOfMongoose)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(handOfRagnaros)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(backstagePass)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(manaCake)));
        }

        [TestMethod]
        public void BackstagePassIncreasesInValueByTwoTenDaysBeforeEvent()
        {
            ItemManager.InitializeInventory();
            updateQuantityNTimes(6);

            backstagePass = new BackstagePass("Backstage passes to a TAFKAL80ETC concert", 9, 27);

            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(backstagePass)));

            updateQuantityNTimes(1);
            backstagePass.Quality += 2;
            backstagePass.SellIn -= 1;

            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(backstagePass)));

            updateQuantityNTimes(1);
            backstagePass.Quality += 2;
            backstagePass.SellIn -= 1;

            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(backstagePass)));
        }

        [TestMethod]
        public void BackstagePassIncreasesInValueByThreeFiveDaysBeforeEvent()
        {
            ItemManager.InitializeInventory();
            updateQuantityNTimes(11);

            backstagePass = new BackstagePass("Backstage passes to a TAFKAL80ETC concert", 4, 38);

            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(backstagePass)));

            updateQuantityNTimes(1);
            backstagePass.Quality += 3;
            backstagePass.SellIn -= 1;

            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(backstagePass)));

            updateQuantityNTimes(1);
            backstagePass.Quality += 3;
            backstagePass.SellIn -= 1;

            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(backstagePass)));
        }

        [TestMethod]
        public void BackstagePassQualityIsZeroAfterConcert()
        {
            ItemManager.InitializeInventory();
            updateQuantityNTimes(16);

            backstagePass = new BackstagePass("Backstage passes to a TAFKAL80ETC concert", -1, 0);

            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(backstagePass)));
        }

        [TestMethod]
        public void AllItemsMaxToMinRun()
        {
            ItemManager.InitializeInventory();
            updateQuantityNTimes(100);

            dexterityVest = new DexterityVest("+5 Dexterity Vest", -90, 0);
            agedBri = new AgedBrie("Aged Brie", -98, 50);
            elixirOfMongoose = new MongooseElixir("Elixir of the Mongoose", -95, 0);
            handOfRagnaros = new Sulfuras("Sulfuras, Hand of Ragnaros", 0, 80);
            backstagePass = new BackstagePass("Backstage passes to a TAFKAL80ETC concert", -85, 0);
            manaCake = new ManaCake("Conjured Mana Cake", -97, 0);

            Assert.AreEqual(6, ItemManager.Items.Count());
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(dexterityVest)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(agedBri)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(elixirOfMongoose)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(handOfRagnaros)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(backstagePass)));
            Assert.IsNotNull(ItemManager.Items.FirstOrDefault(i => i.Equals(manaCake)));
        }

        private void updateQuantityNTimes(Int32 n)
        {
            for (var i = 0; i < n; i++)
                ItemManager.UpdateQuality();
        }

    }
}