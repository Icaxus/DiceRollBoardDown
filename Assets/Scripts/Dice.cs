using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static DG.Tweening.Tween;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{

    private Rigidbody _rigidbody;
    
    public Rigidbody Rigidbody { get { return (_rigidbody == null) ? _rigidbody = GetComponent<Rigidbody>() : _rigidbody; } }

    private Collider _collider;
    public Collider Collider { get { return (_collider == null) ? _collider = GetComponent<Collider>() : _collider; } }
    
    [SerializeField] private float _force = 10.0f;
    [SerializeField] private Vector3 _resetPoint;
    [SerializeField] private List<GameObject> edges;
    protected bool grounded = true;
    protected int diceUp;
    private int _lastDiceEdgeValue = 0;
    [SerializeField] private GameObject _tmpDice;

    #region Events
    [HideInInspector]
    public UnityEvent OnDiceRoll = new UnityEvent();
    #endregion

    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        transform.rotation = Random.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Debug.Log("Grounded space bastık: " + grounded);
            Debug.Log("Space");
            grounded = false;
            
            
            StartCoroutine(DiceRolCoroutine());
            
        }

        
    }

    IEnumerator DiceRolCoroutine()
    {
        _rigidbody.AddForce(Vector3.up * _force * 2, ForceMode.Impulse);
        _rigidbody.AddTorque(Random.rotation.eulerAngles * _force);
        yield return new WaitForSeconds(4);
        grounded = true;
        _lastDiceEdgeValue = DiceUpEdgeValue();
        Debug.Log("Değer: " + _lastDiceEdgeValue);
        DiceResetPosition();
        
    }

    void DiceRoll()
    {
        _rigidbody.AddForce(Vector3.up * _force * 2, ForceMode.Impulse);
        _rigidbody.AddTorque(Random.rotation.eulerAngles * _force);
    }

    public int DiceUpEdgeValue()
    {
        float tempMin = 5;
        int edgeValue = 0;
        foreach (var edge in edges)
        {
            if (edge.transform.position.y < tempMin)
            {
                edgeValue = Int32.Parse(edge.name);
                tempMin = edge.transform.position.y;
            }
        }


        return 7-edgeValue;
    }

    int DiceUpEdge()
    {
        Vector3 rotation = gameObject.transform.rotation.eulerAngles;


        return 0;
    }

    void DiceResetPosition()
    {
        transform.DOMove(_resetPoint,1);
        transform.DORotate(Vector3.back, 1);
    }
}
