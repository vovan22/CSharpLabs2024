namespace Pr4;

public interface ISpell
{
    string Name { get;}
    void Cast(Player target, int magicBonus);
}