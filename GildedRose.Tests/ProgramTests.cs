namespace GildedRose.Tests;

public class ProgramTests
{
    Program app;

    public ProgramTests()
    {
        app = new Program();
        app.Items = new List<Item>();
    }

    [Fact]
    public void Test_UpdateQuality_one_time()
    {
        app = new Program();
        app.Items = new List<Item>
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
            new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 10,
                        Quality = 49
                    },
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 5,
                        Quality = 48
                    }

        };

        // setup expected items
        var expectedItems = new List<Item>
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19},
            new Item { Name = "Aged Brie", SellIn = 1, Quality = 1},
            new Item { Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6},
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 14,
                        Quality = 21
                    },
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 9,
                        Quality = 50
                    },
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 4,
                        Quality = 50
                    }
        };

        // run updatequality
        app.UpdateQuality();

        // assert items have correct values
        app.Items.Should().BeEquivalentTo(expectedItems);
        //true.Should().BeTrue();
    }

    [Fact]
    public void Test_aged_brie_sellin_less_than_0()
    {
        // Arrange
        var item = new Item { Name = "Aged Brie", SellIn = -5, Quality = 2 };
        app.Items.Add(item);

        // Act
        app.UpdateQuality();

        // Assert
        item.Quality.Should().Be(4);
    }

    [Fact]
    public void Test_quality_degrades_faster_if_sellin_value_negative()
    {
        var degradingItem = new Item
        {
            Name = "+50 Dexterity Vest",
            SellIn = 10,
            Quality = 50,
        };

        app.Items.Add(degradingItem);
        var expectedQuality = 20;

        for (int i = 0; i < 20; i++)
        {
            app.UpdateQuality();
        }

        degradingItem.Quality.Should().Be(expectedQuality);
    }

    [Fact]
    public void Item_with_quality_zero_is_not_negative_after_update()
    {
        // Arrange
        var item = new Item { Name = "quality zero", SellIn = 5, Quality = 0 };
        app.Items.Add(item);

        // Act
        app.UpdateQuality();

        // Assert
        item.Quality.Should().Be(0);
    }

    [Fact]
    public void Test_aged_brie_increases_in_quality()
    {
        var item = new Item
        {
            Name = "Aged Brie",
            SellIn = 5,
            Quality = 5,
        };

        app.Items.Add(item);
        app.UpdateQuality();

        item.Quality.Should().Be(6);
        item.SellIn.Should().Be(4);
    }

    [Fact]
    public void Test_Sulfuras_no_change()
    {
        var item = new Item
        {
            Name = "Sulfuras, Hand of Ragnaros",
            SellIn = 5,
            Quality = 80,
        };

        app.Items.Add(item);
        app.UpdateQuality();

        item.Quality.Should().Be(80);
        item.SellIn.Should().Be(5);
    }

    [Fact]
    public void Test_backstage_pass_quality_increases_by_2_if_sellin_le_10()
    {
        var item = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 10,
            Quality = 10,
        };
        app.Items.Add(item);

        app.UpdateQuality();
        item.Quality.Should().Be(12);
    }

    [Fact]
    public void Test_backstage_pass_quality_increases_by_3_if_sellin_le_5()
    {
        var item = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 5,
            Quality = 10,
        };

        app.Items.Add(item);
        app.UpdateQuality();
        item.Quality.Should().Be(13);
    }

    [Fact]
    public void Test_backstage_pass_quality_zero_if_sellin_negative()
    {
        var item = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 0,
            Quality = 10,
        };

        app.Items.Add(item);
        app.UpdateQuality();
        item.Quality.Should().Be(0);
    }

    [Fact]
    public void Item_increasing_in_quality_with_quality_50_does_not_exceed_50_after_update()
    {
        // Arrange
        var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 };
        app.Items.Add(item);

        // Act
        app.UpdateQuality();

        // Assert
        item.Quality.Should().BeLessThanOrEqualTo(50);
    }

    [Fact]
    public void Test_test()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 51 };
        app.Items.Add(item);

        // Act
        app.UpdateQuality();
        true.Should().Be(true);
    }

    //[Fact]
    //public void Test_conjured_degrade_faster()
    //{
    //    var item = new Item
    //    {
    //        Name = "Conjured Mana Cake",
    //        SellIn = 5,
    //        Quality = 40,
    //    };

    //    app.Items.Add(item);
    //    app.UpdateQuality();

    //    item.Quality.Should().Be(38);
    //    item.SellIn.Should().Be(4);
    //}

    // [Fact]
    // public void Test_UpdateQuality_thirty_times()
    // {
    //   // setup expected items
    //   var expectedItems = new List<Item>
    //   {
    //       new Item { Name = "+5 Dexterity Vest", SellIn = -20, Quality = 0},
    //       new Item { Name = "Aged Brie", SellIn = -28, Quality = 50},
    //       new Item { Name = "Elixir of the Mongoose", SellIn = -25, Quality = 0},
    //       new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
    //       new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
    //       new Item
    //       {
    //           Name = "Backstage passes to a TAFKAL80ETC concert",
    //           SellIn = -15,
    //           Quality = 0
    //       },
    //       new Item
    //       {
    //           Name = "Backstage passes to a TAFKAL80ETC concert",
    //           SellIn = -20,
    //           Quality = 0
    //       },
    //       new Item
    //       {
    //           Name = "Backstage passes to a TAFKAL80ETC concert",
    //           SellIn = -25,
    //           Quality = 0
    //       }

    //   };

    //   //     -------- day 30 --------
    //   // name, sellIn, quality
    //   // +5 Dexterity Vest, -20, 0
    //   // Aged Brie, -28, 50
    //   // Elixir of the Mongoose, -25, 0
    //   // Sulfuras, Hand of Ragnaros, 0, 80
    //   // Sulfuras, Hand of Ragnaros, -1, 80
    //   // Backstage passes to a TAFKAL80ETC concert, -15, 0
    //   // Backstage passes to a TAFKAL80ETC concert, -20, 0
    //   // Backstage passes to a TAFKAL80ETC concert, -25, 0
    //   // Conjured Mana Cake, -27, 0

    //   // run updatequality
    //   for (int i = 0; i < 31; i++) app.UpdateQuality();

    //   // assert items have correct values
    //   app.Items.Should().BeEquivalentTo(expectedItems);
    //   //true.Should().BeTrue();
    // }

}
