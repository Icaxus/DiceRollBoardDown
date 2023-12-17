using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : Singleton<DiceManager>
{
    [SerializeField]
    private List<Dice> dices;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetDiceUpEdges()
    {
        return dices[0].GetComponent<Dice>().DiceUpEdgeValue() + "-" + dices[1].GetComponent<Dice>().DiceUpEdgeValue();
    }
    
}
