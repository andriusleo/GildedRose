namespace GildedRose.Console.Updaters
{
    public class AgingItemUpdater : RegularItemUpdater
    {
        protected override int GetQualityDelta(Item item)
        {
            return item.SellIn > 0 ? 1 : 2;
        }
    }
}