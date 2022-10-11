public class AgedBrieItem : Item
{
    public override void UpdateQuality() => Quality += SellIn >= 0 ? 1 : 2;
}
