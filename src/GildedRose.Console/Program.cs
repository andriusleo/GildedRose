namespace GildedRose.Console
{
    using System.Collections.Generic;

    public class Program
    {
        // Do not touch because this belongs to the goblin in the corner. :)
        IList<Item> Items;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }

            };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        // This is needed because cannot modify "Items" field.
        public void SetItemsValue(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            if (Items == null || Items.Count < 1)
            {
                return;
            }

            foreach (var item in Items)
            {
                var itemTypeUpdater = ItemTypeUpdaterFactory.GetItemTypeUpdater(item.Name);
                itemTypeUpdater.Update(item);
            }
        }
    }
}