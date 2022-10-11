public abstract class Item
{
    public string? Name { get; set; }

    public int SellIn { get; set; }

    public int Quality { get; set; }

    public abstract void UpdateQuality();

    public virtual void Update()
    {
        SellIn--;

        UpdateQuality();
        Quality = Math.Min(Quality, 50);
        Quality = Math.Max(Quality, 0);
    }
}
