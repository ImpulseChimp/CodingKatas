using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRoseKata.Strategies;
using GildedRoseKata.Items;

namespace GildedRoseKataTests
{
    [TestClass]
    public class BrieStrategyTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var strategy = new BrieStrategy();

            var sellIn = 10;
            var item = new Item() { Name = "some name", Quality = 10, SellIn = sellIn };

            strategy.UpdateItem(item);

            Assert.AreEqual(sellIn - 1, item.SellIn);
        }
    }
}
