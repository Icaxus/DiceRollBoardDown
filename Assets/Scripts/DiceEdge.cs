using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiceEdge : Dice
{

    private void Awake()
    {
        

    }

    private void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
           
        }
    }
}

