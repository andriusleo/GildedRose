﻿namespace GildedRose.Console.Updaters
{
    public class AgingItemUpdater : NormalItemUpdater
    {
        protected override int GetQualityDelta(Item item)
        {
            return item.SellIn > 0 ? 1 : 2;
        }
    }
}