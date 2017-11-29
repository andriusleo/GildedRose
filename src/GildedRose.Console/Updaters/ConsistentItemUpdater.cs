namespace GildedRose.Console.Updaters
{
    internal class ConsistentItemUpdater : IItemTypeUpdater
    {
        public void Update(Item item)
        {
            // Do nothing! Quality and SellIn values never changes.
        }
    }
}