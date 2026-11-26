namespace Homework9.Combat;

internal static class Program
{
    private static void Main()
    {
        ICombatant knight = new Knight("Артур");
        ICombatant mage = new Mage("Мерлин");

        while (!knight.IsDead && !mage.IsDead)
        {
            knight.Attack(mage);

            if (!mage.IsDead)
            {
                mage.Attack(knight);
            }
        }

        string winner = knight.IsDead ? $"Маг {mage.Name}" : $"Рыцарь {knight.Name}";
        Console.WriteLine($"Победил {winner}!");
    }
}
