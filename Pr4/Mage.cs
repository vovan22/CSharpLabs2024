using System.Diagnostics;

namespace Pr4;

public class Mage : Player
{
    private static MagicSkillsets _magicList = new MagicSkillsets();
    private Dictionary<MagicType, List<ISpell>> _spellsByMagic = _magicList.Magic;
    private int _magicLevel;

    public int MagicLevel
    {
        get => _magicLevel;
        set => _magicLevel = value > 10 ? 10 : value;
    }

    public List<ISpell> Spells { get; set; }

    public MagicType Magic { get; set; }

    public Mage()
    {
        Name = "NaN";
        Surname = "NaN";
        Hp = 100;
        Magic = MagicType.Fire;
        Spells = _spellsByMagic[Magic];
        MagicLevel = 1;
    }
    
    public Mage(string name,string surname,int hp,MagicType magic, List<ISpell> spellList, int magicLevel) : base()
    {
        Name = name;
        Surname = surname;
        Hp = hp;
        Magic = magic;
        Spells = spellList;
        MagicLevel = magicLevel;
    }

    public override void CastSpell(int spellID, Player target)
    {
        Console.Write(Name + " ");
        Spells[spellID].Cast(target, MagicLevel);
        Console.WriteLine($"{target.Name} hp: {target.Hp}");
    }

    public void PrintSpellsList()
    {
        int i = 0;
        foreach (ISpell spell in Spells)
        {
            Console.WriteLine(spell is AttackingSpell ? $"{i} - {spell.Name} (attack)" : $"{i} - {spell.Name} (heal)");
            ++i;
        }
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Magic: {Magic}");
        Console.WriteLine($"Magic level: {MagicLevel}");
    }

    public override void PlayerCreator()
    {
        base.PlayerCreator();
        bool isMagicExists = false;
        do
        {
            Console.Write("Player's magic (type 'list' for magic list): ");
            string magic = Console.ReadLine();

            if (magic != null && magic.ToLower() == "list")
            {
                _magicList.PrintMagicInfo();
            }
            else
            {
                foreach (var kvp in _spellsByMagic)
                {
                    if (kvp.Key.ToString().ToLower() == magic.ToLower())
                    {
                        Magic = kvp.Key;
                        Spells = _spellsByMagic[kvp.Key];
                        isMagicExists = true;
                        break;
                    }
                }  
            }
            
            if (!isMagicExists && magic.ToLower() != "list")
            {
                Console.WriteLine("Unknown magic...");
            }
        } while (!isMagicExists);
        
        
        do
        {
            Console.Write("Player's magic level: ");
            try
            {
                MagicLevel = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Wrong MagicLevel value!");
                continue;
            }
            break;
        } while (true);
    }
}