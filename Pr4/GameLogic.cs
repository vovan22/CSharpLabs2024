namespace Pr4;

public class GameLogic
{
    private Player _player1 = new Mage();
    private Player _player2 = new Mage();
    private int _playerTurn = 1;
    private bool _gameContinuation = true;
    private bool _assignNewValues = true;

    public GameLogic(){}

    public void StartPvPGame()
    {
        do
        {
            if (_assignNewValues)
            {
                Console.WriteLine("Player1 creating:");
                _player1.PlayerCreator();
                Console.Clear();
                Console.WriteLine("Player2 creating:");
                _player2.PlayerCreator();
                Console.Clear();
            }

            Player originalValuesP1 = _player1;
            Player originalValuesP2 = _player2;
            
            Console.WriteLine("----------------Player1 stats----------------");
            ((Mage)_player1).ShowInfo();
            Console.WriteLine("Spells list:");
            ((Mage)_player1).PrintSpellsList();
            Console.WriteLine("----------------Player2 stats----------------");
            ((Mage)_player2).ShowInfo();
            Console.WriteLine("Spells list:");
            ((Mage)_player2).PrintSpellsList();
            Console.WriteLine("Type 'slist' to see list of your spells");
            do
            {
                bool correctInput = false;
                int spellID;
                do
                {
                    Console.WriteLine(_playerTurn % 2 == 0 ? "Player2's turn" : "Player1's turn");

                    string playerInput = Console.ReadLine();

                    if (int.TryParse(playerInput, out spellID))
                    {
                        if (_playerTurn % 2 == 0 && spellID <= ((Mage)_player2).Spells.Count-1 && spellID >= 0)
                        {
                            correctInput = true;
                        }
                        else if (_playerTurn % 2 != 0 && spellID <= ((Mage)_player1).Spells.Count - 1 && spellID >= 0)
                        {
                            correctInput = true;
                        }
                        else
                        {
                            Console.WriteLine("SpellID is out of spells range");
                        }
                    }
                    else if (playerInput.ToLower() == "slist")
                    {
                        if (_playerTurn%2==0)
                        {
                            ((Mage)_player2).PrintSpellsList();
                        }
                        else
                        {
                            ((Mage)_player1).PrintSpellsList();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect value!");
                    }
                    
                } while (!correctInput);
            
                if (_playerTurn % 2 == 0)
                {
                    _player2.CastSpell(spellID, ((Mage)_player2).Spells[spellID] is AttackingSpell ? _player1 : _player2);
                }
                else
                {
                    _player1.CastSpell(spellID, ((Mage)_player1).Spells[spellID] is AttackingSpell ? _player2 : _player1);
                }

                ++_playerTurn;

                if (_player1.Hp == 0 )
                {
                    Console.WriteLine("\nPlayer2 win!");
                }
                else if (_player2.Hp == 0 )
                {
                    Console.WriteLine("\nPlayer1 win!");
                }
            
            } while (_player1.Hp>0 && _player2.Hp>0);
            Console.WriteLine("Would you like to play again?(y/n)");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "yes" || choice.ToLower() == "y")
            {
                Console.WriteLine("Would you like to keep mages' stats same?(y/n)");
                string inputToChange = Console.ReadLine();
                if (inputToChange.ToLower() == "yes" || inputToChange.ToLower() == "y")
                {
                    _player1 = originalValuesP1;
                    _player2 = originalValuesP2;
                    _assignNewValues = false;
                }
            }
            else
            {
                _gameContinuation = false;
            }
            Console.Clear();
        } while (_gameContinuation);
    }

    public void StartPvAIGame(){}

}