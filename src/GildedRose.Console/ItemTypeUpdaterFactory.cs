namespace GildedRose.Console
{
    using Updaters;

    public static class ItemTypeUpdaterFactory
    {
        public static IItemTypeUpdater GetItemTypeUpdater(string itemName)
        {
            switch (itemName)
            {
                case ItemNames.Aged_Brie:
                    return new AgingItemUpdater();
                case ItemNames.Backstage_Passes_To_A_TAFKAL80ETC_Concert:
                    return new BackstagePassItemUpdater();
                case ItemNames.Sulfuras_Hand_Of_Ragnaros:
                    return new ConsistentItemUpdater();
                default:
                    return new RegularItemUpdater();
            }
        }
    }
}