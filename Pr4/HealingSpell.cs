namespace Pr4;

public class HealingSpell : ISpell
{
    private int Healing { get; }
    public string Name { get; }

    public HealingSpell(int healing, string name)
    {
        Healing = healing;
        Name = name;
    }

    public void Cast(Player target, int magicBonus)
    {
       target.TakeHealing(Healing * (int)(magicBonus * 0.5));
       Console.WriteLine($"using {Name} on {target.Name}");
    }
}