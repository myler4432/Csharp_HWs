namespace Homework9.Items;

internal static class Program
{
    private static void Main()
    {
        Player player = new Player("Артур", hp: 100, damage: 20);
        List<IUsableItem> items = new List<IUsableItem>
        {
            new HealthPotion(),
            new Sword(),
            new AncientScroll()
        };

        foreach (IUsableItem item in items)
        {
            item.Use(player);
        }

        string state = player.IsDead ? "мёртв" : "жив";
        Console.WriteLine($"{player.Name}. HP: {player.HP}. Урон: {player.Damage}. Состояние: {state}.");
    }
}
