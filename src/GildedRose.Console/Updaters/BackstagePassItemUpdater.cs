namespace GildedRose.Console.Updaters
{
    public class BackstagePassItemUpdater : RegularItemUpdater
    {
        protected override int GetQualityDelta(Item item)
        {
            int qualityDelta;

            if (item.SellIn > 10)
            {
                qualityDelta = 1;
            }
            else if (item.SellIn <= 10 && item.SellIn > 5)
            {
                qualityDelta = 2;
            }
            else if (item.SellIn <= 5 && item.SellIn > 0)
            {
                qualityDelta = 3;
            }
            else
            {
                qualityDelta = item.Quality * -1;
            }

            return qualityDelta;
        }
    }
}