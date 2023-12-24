using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using DG.Tweening;
using Unity.VisualScripting.FullSerializer;
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
        
        if (ManOpen(_mans[diceSum-1]))
        {
            Debug.Log("Döndürüyor beni.");
            _mans[diceSum - 1].transform.DORotate(new Vector3(_mans[diceSum-1].transform.rotation.eulerAngles.x,_mans[diceSum-1].transform.rotation.eulerAngles.y,-45), 1);
            return;
        }

        bool problem = false;
        foreach (var diceValue in diceValues)    
        {
            if (ManOpen(_mans[diceValue-1]))
            {
                _mans[diceValue-1].transform.DORotate(new Vector3(_mans[diceSum-1].transform.rotation.eulerAngles.x,_mans[diceSum-1].transform.rotation.eulerAngles.y,-45), 1);
            }
            else
            {
                problem = true;
            }
        }

        if (problem)
        {
            Debug.Log("Problem");
            ResetMans();
        }
        
        return;

        diceValues.RemoveAt(diceValues.Count-1);
       
        foreach (var dice in diceValues)
        {
            
        }
    }

    private void ResetMans()
    {
        foreach (var man in _mans)
        {
            man.Reset();
        }
    }

    private bool ManOpen(Man man)
    {
        return man.ManClosable();
    }
}
