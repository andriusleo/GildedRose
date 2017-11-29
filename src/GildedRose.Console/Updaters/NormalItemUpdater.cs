namespace GildedRose.Console.Updaters
{
    internal class NormalItemUpdater : IItemTypeUpdater
    {
        private const int MinQuality = 0;

        private const int MaxQuality = 50;

        public void Update(Item item)
        {
            var qualityDelta = GetQualityDelta(item);
            item.Quality = GetNewQuality(item.Quality, qualityDelta);

            item.SellIn = item.SellIn - 1;
        }

        private int GetNewQuality(int quality, int qualityDelta)
        {
            var newQuality = quality + qualityDelta;
            return newQuality < MinQuality ? MinQuality : newQuality > MaxQuality ? MaxQuality : newQuality;
        }

        protected virtual int GetQualityDelta(Item item)
        {
            return item.SellIn > 0 ? -1 : -2;
        }
    }
}