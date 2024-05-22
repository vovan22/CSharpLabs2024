namespace Pr4;

public interface IDamageable
{
    int Hp { get; set; }

    void TakeDamage(int damage);
}