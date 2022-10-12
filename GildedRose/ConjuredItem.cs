public class ConjuredItem : Item
{
    public override void UpdateQuality() => Quality -= SellIn >= 0 ? 2 : 4;
}