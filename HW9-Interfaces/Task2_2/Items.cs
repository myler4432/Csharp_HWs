namespace Homework9.Items;

public class HealthPotion : IUsableItem
{
    private const int Healing = 50;

    public string Name => "Зелье здоровья";
    public string Description => $"Восстанавливает {Healing} HP.";
    public Rarity Rarity => Rarity.Common;

    public void Use(Player player)
    {
        player.Heal(Healing);
        Console.WriteLine($"Вы выпили зелье и восстановили {Healing} HP.");
    }
}

public class Sword : IUsableItem
{
    private const int DamageBonus = 10;

    public string Name => "Меч";
    public string Description => $"Повышает урон на {DamageBonus}.";
    public Rarity Rarity => Rarity.Rare;

    public void Use(Player player)
    {
        player.IncreaseDamage(DamageBonus);
        Console.WriteLine($"Вы взяли меч. Урон вырос на {DamageBonus}.");
    }
}

public class AncientScroll : IUsableItem
{
    private const int CurseDamage = 20;
    private const int DamageBonus = 30;

    public string Name => "Древний свиток";
    public string Description => $"Наносит {CurseDamage} урона и повышает урон игрока на {DamageBonus}.";
    public Rarity Rarity => Rarity.Legendary;

    public void Use(Player player)
    {
        player.TakeDamage(CurseDamage);
        player.IncreaseDamage(DamageBonus);
        Console.WriteLine($"Вы прочитали свиток. Проклятие нанесло {CurseDamage} урона, а ваш урон вырос на {DamageBonus}.");
    }
}
