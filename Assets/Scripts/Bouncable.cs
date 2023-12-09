using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bouncable : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _force = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        transform.rotation = Random.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Debug.Log("Space pressed");
            //_rigidbody.AddExplosionForce(5f, transform.position, 5.0f, 3.0f);
            _rigidbody.AddForce(Vector3.up * _force * 2, ForceMode.Impulse);
            _rigidbody.AddTorque(Random.rotation.eulerAngles * _force);
            
        }
    }
}
