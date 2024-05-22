namespace Pr4;

public interface IHealable
{
    int Hp { get; set; }

    void TakeHealing(int healing);
}