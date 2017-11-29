namespace GildedRose.Console.Updaters
{
    public class ConjuredItemUpdater : NormalItemUpdater
    {
        protected override int GetQualityDelta(Item item)
        {
            return base.GetQualityDelta(item) * 2;
        }
    }
}