namespace Homework9.Damage;

internal static class Program
{
    private static void Main()
    {
        Unit target = new Unit("Страж", hp: 200, armor: 40);
        const int baseDamage = 60;

        DamageSystem physical = new DamageSystem(new PhysicalDamageCalculator());
        DamageSystem magic = new DamageSystem(new MagicDamageCalculator());
        DamageSystem fire = new DamageSystem(new FireDamageCalculator());

        Console.WriteLine("Физический урон");
        physical.ApplyDamage(target, baseDamage);
        Console.WriteLine("Магический урон");
        magic.ApplyDamage(target, baseDamage);
        Console.WriteLine("Огненный урон");
        fire.ApplyDamage(target, baseDamage);

        // Для ледяного урона создаём IceDamageCalculator с реализацией
        // IDamageCalculator и передаём его в конструктор DamageSystem.
        // Сам DamageSystem продолжает вызывать CalculateDamage через интерфейс.
    }
}
