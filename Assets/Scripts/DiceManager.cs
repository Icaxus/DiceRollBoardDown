using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : Singleton<DiceManager>
{
    public static List<int> _diceValues;
    public static List<int> DiceValues
    {
        get { return _diceValues; }
    }
    
    [SerializeField] private static List<Dice> dices;
    public static List<Dice> Dices
    {
        get { return dices; }
    }

    private bool diceRolled = false;
    // Start is called before the first frame update
    void Start()
    {
        _diceValues = new List<int>();
        EventManager.OnDiceRolled.AddListener(GetDiceUpEdges);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDiceUpEdges()
    {
        
        int diceSum = 0;
        foreach (var dice in dices)
        {
            _diceValues.Add(dice.DiceValue);
            diceSum += dice.DiceValue;
        }
        _diceValues.Add(diceSum);
        

    }
    
}
