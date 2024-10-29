using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using GildedRoseKata;
using VerifyTests;
using VerifyXunit;
using static VerifyXunit.Verifier;

namespace GildedRoseTests;

public class GildedRoseTest
{
    // [Fact]
    // public void Test_Item_Should_Return_Expected_Values()
    // {
    //     var items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
    //     var app = new GildedRose(items);
    //     app.UpdateQuality();
    //     items[0].Name.Should().Be("foo");
    //     items[0].SellIn.Should().Be(-1);
    //     items[0].Quality.Should().Be(0);
    // }


    [Fact]
    public Task GildedRose_UpdateQuality_Should_Return_Correct_Values()
    {
        string[] names = ["foo", "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros" ];
        int[] qualities = [0,-1,1,49,50,51];
        int[] sellIns = [100,5,6,10,11,0,-1];
        var random = new Random();
        var next = random.Next(1,3);
        return next == 1 ? VerifyCombinations(GildedRoseOriginalQualityUpdater, names, qualities, sellIns) : VerifyCombinations(GildedRoseQualityUpdater, names, qualities, sellIns);
    }

    private static string GildedRoseQualityUpdater(string name, int quality, int sellIn)
    {
        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        var item = items[0];
        return $"{item.Name}#{item.SellIn}#{item.Quality}";
    }
    
    private static string GildedRoseOriginalQualityUpdater(string name, int quality, int sellIn)
    {
        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRoseOriginal(items);
        app.UpdateQuality();
        var item = items[0];
        return $"{item.Name}#{item.SellIn}#{item.Quality}";
    }
}