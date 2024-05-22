namespace Pr4;

public abstract class Player : IDamageable, IHealable
{

    protected int _hp;

    public int Hp
    {
        get => _hp;
        set => _hp = value < 0 ? 0 : value;
    }

    public string Name { get; set; }

    public string Surname { get; set; }

    public void TakeHealing(int healing)
    {
        Hp += healing;
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;
    }

    public abstract void CastSpell(int spellID, Player target);

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Surname: {Surname}");
        Console.WriteLine($"Hp: {Hp}");
    }

    public virtual void PlayerCreator()
    {
        Console.Write("Player's name: ");
        Name = Console.ReadLine();
        Console.Write("Player's surname: ");
        Surname = Console.ReadLine();
        do
        {
            int hpPlaceholder;
            Console.Write("Player's hp: ");
            try
            {
                hpPlaceholder = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Wrong HP value!");
                continue;
            }

            Hp = hpPlaceholder > 0 ? hpPlaceholder : 1;
            
            break;
        } while (true);
    }

}