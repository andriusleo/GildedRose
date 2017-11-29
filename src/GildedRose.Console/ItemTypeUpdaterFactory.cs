namespace GildedRose.Console
{
    using System;
    using Updaters;

    internal static class ItemTypeUpdaterFactory
    {
        // This logic could/should be improved according to the business rules...
        internal static IItemTypeUpdater GetItemTypeUpdater(string itemName)
        {
            if (itemName.StartsWith("Aged Brie", StringComparison.InvariantCultureIgnoreCase))
            {
                return new AgingItemUpdater();
            }
            if (itemName.StartsWith("Backstage passes", StringComparison.InvariantCultureIgnoreCase))
            {
                return new BackstagePassItemUpdater();
            }
            if (itemName.StartsWith("Sulfuras", StringComparison.InvariantCultureIgnoreCase))
            {
                return new ConsistentItemUpdater();
            }
            if (itemName.StartsWith("Conjured", StringComparison.InvariantCultureIgnoreCase))
            {
                return new ConjuredItemUpdater();
            }

            return new NormalItemUpdater();
        }
    }
}