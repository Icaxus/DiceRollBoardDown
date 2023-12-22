using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Desk : MonoBehaviour
{
    [SerializeField] private List<Man> _mans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseMans(List<int> diceValues)
    {
        int diceSum = diceValues.Last();
        diceValues.RemoveAt(diceValues.Count-1);
        
        {
            
        }
        foreach (var dice in diceValues)
        {
            if (CheckMan(_mans[dice - 1]))
            {
                
            }
        }
    }

    private bool CheckMan(Man man)
    {
        return man.ManClosable();
    }
}
