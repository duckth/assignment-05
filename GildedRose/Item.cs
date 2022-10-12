public class Item
{
    /*
        The Update() function decrements the SellIn value, 
        calls the UpdateQuality() function and ensures the quality is within the limit.
        This logic is shared between all item types (except Legendary), and as such
        we have less code duplication. By marking the functions 'virtual',
        we let the derived types override the function with correct logic for their type.
        By using inheritance, we can have a single list in the Program that contains
        elements of the type 'Item', and since all derived types inherit or override Update(),
        we can call that and let the items themselves handle the logic.
    */

    public string? Name { get; set; }

    public int SellIn { get; set; }

    public int Quality { get; set; }

    public virtual void UpdateQuality() => Quality -= SellIn >= 0 ? 1 : 2;

    public virtual void Update()
    {
        SellIn--;

        UpdateQuality();
        Quality = Math.Min(Quality, 50);
        Quality = Math.Max(Quality, 0);
    }
}
