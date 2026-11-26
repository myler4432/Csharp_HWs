namespace Homework9.Items;

public class Player
{
    public string Name { get; }
    public int HP { get; private set; }
    public int Damage { get; private set; }
    public bool IsDead => HP <= 0;

    public Player(string name, int hp, int damage)
    {
        Name = name;
        HP = hp;
        Damage = damage;
    }

    public void Heal(int amount)
    {
        HP += amount;
    }

    public void IncreaseDamage(int amount)
    {
        Damage += amount;
    }

    public void TakeDamage(int amount)
    {
        HP = Math.Max(0, HP - amount);
    }
}
