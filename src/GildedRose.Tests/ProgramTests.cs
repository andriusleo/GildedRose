namespace GildedRose.Tests
{
    using System.Collections.Generic;
    using Console;
    using NUnit.Framework;

    [TestFixture]
    public class ProgramTests
    {
        [SetUp]
        public void Init()
        {
            _program = new Program();
        }

        private Program _program;

        private Item TestUpdateQualityForSingleItem(string name, int sellIn, int quality)
        {
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };
            _program.SetItemsValue(new List<Item> { item });

            _program.UpdateQuality();

            return item;
        }

        [TestCase("Elixir of the Mongoose", 10, 10, ExpectedResult = 9)]
        [TestCase("Conjured Mana Cake", -5, 30, ExpectedResult = -6)]
        public int UpdateQuality_RegularItems_SellInDecreasesEachDay(string name, int sellIn, int quality)
        {
            var item = TestUpdateQualityForSingleItem(name, sellIn, quality);

            return item.SellIn;
        }

        [Test]
        public void UpdateQuality_RegularItems_QualityDecreasesEachDayBeforeSellByDate()
        {
            var item = TestUpdateQualityForSingleItem(name: "Super drink", sellIn: 14, quality: 38);

            Assert.AreEqual(37, item.Quality);
        }

        [TestCase("+5 Dexterity Vest", 0, 10, ExpectedResult = 8)]
        [TestCase("Conjured Mana Cake", -2, 4, ExpectedResult = 2)]
        public int UpdateQuality_RegularItems_QualityDecreasesTwiceAfterSellByDate(string name, int sellIn, int quality)
        {
            var item = TestUpdateQualityForSingleItem(name, sellIn, quality);

            return item.Quality;
        }

        [TestCase("+5 Dexterity Vest", 5, 0)]
        [TestCase("Elixir of the Mongoose", -10, 0)]
        public void UpdateQuality_RegularItems_QualityIsNeverNegative(string name, int sellIn, int quality)
        {
            var item = TestUpdateQualityForSingleItem(name, sellIn, quality);

            Assert.GreaterOrEqual(item.Quality, 0);
        }

        [Test]
        public void UpdateQuality_AgingItems_QualityIncreasesWithAgeBeforeSellByDate()
        {
            var item = TestUpdateQualityForSingleItem(name:"Aged Brie", sellIn:7, quality:10);

            Assert.AreEqual(11, item.Quality);
        }

        [Test]
        public void UpdateQuality_AgingItems_QualityIncreasesWithAgeTwiceAfterSellByDate()
        {
            var item = TestUpdateQualityForSingleItem(name: "Aged Brie", sellIn: -3, quality: 20);

            Assert.AreEqual(22, item.Quality);
        }

        [TestCase("Aged Brie", 2, 50)]
        [TestCase("Aged Brie", -12, 50)]
        public void UpdateQuality_AgingItems_QualityCannotExceed50(string name, int sellIn, int quality)
        {
            var item = TestUpdateQualityForSingleItem(name, sellIn, quality);

            Assert.LessOrEqual(item.Quality, 50);
        }

        [TestCase("Backstage passes to a TAFKAL80ETC concert", 12, 50)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 7, 50)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 3, 50)]
        public void UpdateQuality_BackstagePassItems_QualityCannotExceed50(string name, int sellIn, int quality)
        {
            var item = TestUpdateQualityForSingleItem(name, sellIn, quality);

            Assert.LessOrEqual(item.Quality, 50);
        }

        [Test]
        public void UpdateQuality_ConsistentItems_SellInIsAlwaysTheSame()
        {
            var item = TestUpdateQualityForSingleItem(name: "Sulfuras, Hand of Ragnaros", sellIn: 10, quality: 80);

            Assert.AreEqual(10, item.SellIn);
        }

        [TestCase("Sulfuras, Hand of Ragnaros", 7, 80, ExpectedResult = 80)]
        [TestCase("Sulfuras, Hand of Ragnaros", -7, 80, ExpectedResult = 80)]
        public int UpdateQuality_ConsistentItems_QualityIsAlwaysTheSame(string name, int sellIn, int quality)
        {
            var item = TestUpdateQualityForSingleItem(name, sellIn, quality);

            return item.Quality;
        }

        [Test]
        public void UpdateQuality_BackstagePassItems_QualityIncreasesWithAgeWhenSellInMoreThan10Days()
        {
            var item = TestUpdateQualityForSingleItem(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 11, quality: 30);

            Assert.AreEqual(31, item.Quality);
        }

        [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 10, ExpectedResult = 12)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 6, 20, ExpectedResult = 22)]
        public int UpdateQuality_BackstagePassItems_QualityIncreasesWithAgeTwiceWhenSellInBetween10And6Days(string name, int sellIn, int quality)
        {
            var item = TestUpdateQualityForSingleItem(name, sellIn, quality);

            return item.Quality;
        }

        [Test]
        public void UpdateQuality_BackstagePassItems_QualityIncreasesWithAgeThriceWhenSellIn5DaysOrLess()
        {
            var item = TestUpdateQualityForSingleItem(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 5, quality: 30);

            Assert.AreEqual(33, item.Quality);
        }

        [Test]
        public void UpdateQuality_BackstagePassItems_QualityIs0AfterSellByDate()
        {
            var item = TestUpdateQualityForSingleItem(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 0, quality: 40);

            Assert.AreEqual(0, item.Quality);
        }
    }
}