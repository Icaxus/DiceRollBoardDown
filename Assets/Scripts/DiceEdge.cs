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
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (grounded)
            {
                // Debug.Log("Zarın değeri: " + diceUp);
                // Debug.Log("Zarın alt yüzeyi: " + this.name);
                // Debug.Log("Zarın adı: " + base.gameObject.name);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            base.grounded = true;
            base.diceUp = 7 - Int32.Parse(this.name.ToString());
            // Debug.Log("Zarın değeri: " + diceUp);
            // Debug.Log("Zarın adı: " + this.name);
        }
    }
}

[ExecuteAlways]
class LockLocalPosition : MonoBehaviour {
#if UNITY_EDITOR
    void Update () {
        transform.localPosition = Vector3.zero;
    }
#endif
}

