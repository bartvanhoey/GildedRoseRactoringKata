using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    public void UpdateQuality()
    {
        foreach (var item in items) UpdateQualityItem(item);
    }

    private static void UpdateQualityItem(Item item)
    {
        item.IfAgedBrieUpdateQuality();
        item.IfBackstageUpdateQuality();
        item.IfEverythingElseUpdateQuality();
    }
}