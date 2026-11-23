namespace Homework9.Combat;

public interface ICombatant
{
    string Name { get; }
    int HP { get; set; }
    bool IsDead { get; }
    int Damage { get; }

    void Attack(ICombatant target);
    void TakeDamage(int amount);
}
