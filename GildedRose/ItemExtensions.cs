namespace GildedRoseKata;

public static class ItemExtensions
{
    public static void IfAgedBrieUpdateQuality(this Item item)
    {
        if (item.Name != "Aged Brie") return;
        if (item.Quality < 50) item.Quality += 1;
        item.SellIn -= 1;
        if (item.SellIn >= 0) return;
        if (item.Quality < 50) item.Quality += 1;
    }

    public static void IfBackstageUpdateQuality(this Item item)
    {
        if (item.Name != "Backstage passes to a TAFKAL80ETC concert") return;
        if (item.Quality < 50)
        {
            item.Quality += 1;
            if (item.SellIn < 11 && item.Quality < 50) item.Quality += 1;
            if (item.SellIn < 6 && item.Quality < 50) item.Quality += 1;
        }
        item.SellIn -= 1;
        if (item.SellIn < 0) item.Quality -= item.Quality;
    }

    public static void IfEverythingElseUpdateQuality(this Item item)
    {
        if (item.Name is "Aged Brie" or "Backstage passes to a TAFKAL80ETC concert") return;
        if (item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros") item.Quality -= 1;
        if (item.Name != "Sulfuras, Hand of Ragnaros") item.SellIn -= 1;
        if (item.SellIn >= 0) return;
        if (item.Quality <= 0) return;
        if (item.Name != "Sulfuras, Hand of Ragnaros") item.Quality -= 1;
    }
}