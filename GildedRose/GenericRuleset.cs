using GildedRose;

public class GenericRuleset : IRuleset
{
    public void UpdateQuality(Item i)
    {
        if (i.Name != "Aged Brie" && i.Name != "Backstage passes to a TAFKAL80ETC concert")
        {
            if (i.Quality > 0)
            {
                if (i.Name != "Sulfuras, Hand of Ragnaros")
                {
                    i.Quality = i.Quality - 1;
                }
            }
        }
        else
        {
            if (i.Quality < 50)
            {
                i.Quality = i.Quality + 1;

                if (i.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (i.SellIn < 11)
                    {
                        if (i.Quality < 50)
                        {
                            i.Quality = i.Quality + 1;
                        }
                    }

                    if (i.SellIn < 6)
                    {
                        if (i.Quality < 50)
                        {
                            i.Quality = i.Quality + 1;
                        }
                    }
                }
            }
        }

        if (i.Name != "Sulfuras, Hand of Ragnaros")
        {
            i.SellIn = i.SellIn - 1;
        }

        if (i.SellIn < 0)
        {
            if (i.Name != "Aged Brie")
            {
                if (i.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (i.Quality > 0)
                    {
                        if (i.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            i.Quality = i.Quality - 1;
                        }
                    }
                }
                else
                {
                    i.Quality = i.Quality - i.Quality;
                }
            }
            else
            {
                if (i.Quality < 50)
                {
                    i.Quality = i.Quality + 1;
                }
            }
        }

    }
}
