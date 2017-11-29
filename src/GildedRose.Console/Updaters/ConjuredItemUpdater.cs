namespace GildedRose.Console.Updaters
{
    internal class ConjuredItemUpdater : NormalItemUpdater
    {
        protected override int GetQualityDelta(Item item)
        {
            return base.GetQualityDelta(item) * 2;
        }
    }
}