namespace GildedRose.Console.Updaters
{
    internal class BackstagePassItemUpdater : NormalItemUpdater
    {
        protected override int GetQualityDelta(Item item)
        {
            if (item.SellIn > 10)
            {
                return 1;
            }
            if (item.SellIn <= 10 && item.SellIn > 5)
            {
                return 2;
            }
            if (item.SellIn <= 5 && item.SellIn > 0)
            {
                return 3;
            }

            return item.Quality * -1;
        }
    }
}