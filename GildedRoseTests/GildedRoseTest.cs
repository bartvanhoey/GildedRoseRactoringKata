﻿using Xunit;
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
    [Fact]
    public void Test_Item_Should_Return_Expected_Values()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();

        items[0].Name.Should().Be("foo");
        items[0].SellIn.Should().Be(-1);
        items[0].Quality.Should().Be(0);
        
    }
    
    [Fact]
    public Task Approval_Test_Item_Should_Return_Expected_Values()
    {
        string[] names = ["foo"];

        var items = GetItemsForVerifying(names[0]);
        
        return Verifier.Verify(items);
                
    }

    private static List<Item> GetItemsForVerifying(string name)
    {
        var items = new List<Item> { new() { Name = name, SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        return items;
    }
}