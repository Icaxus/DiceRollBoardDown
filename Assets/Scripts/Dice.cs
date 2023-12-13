using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _force = 10.0f;
    [SerializeField] private List<GameObject> edges;
    protected bool grounded;
    protected int diceUp;
    [SerializeField] private GameObject _tmpDice;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        transform.rotation = Random.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
             
            
            
        }

        
    }

    void DiceRolled()
    {
        _rigidbody.AddForce(Vector3.up * _force * 2, ForceMode.Impulse);
        _rigidbody.AddTorque(Random.rotation.eulerAngles * _force);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
