namespace GildedRose.Console.Updaters
{
    internal class AgingItemUpdater : NormalItemUpdater
    {
        protected override int GetQualityDelta(Item item)
        {
            return item.SellIn > 0 ? 1 : 2;
        }
    }
}