using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Events;

public class Dice : MonoBehaviour
{
    [SerializeField] private float _force = 10.0f;
    [SerializeField] private Vector3 _resetPoint;
    [SerializeField] private List<GameObject> edges;
    [SerializeField] private GameObject _tmpDice;
    private Collider _collider;

    private int _lastDiceEdgeValue = 0;

    protected int diceValue;
    public int DiceValue
    {
        get => diceValue;
        private set => diceValue = value;
    }    
    
    private Rigidbody _rigidbody;
    protected bool grounded = true;


    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        transform.rotation = Random.rotation;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            //Debug.Log("Grounded space bastık: " + grounded);
            //Debug.Log("Space");
            grounded = false;
            StartCoroutine(DiceRolCoroutine());
        }
    }

    private IEnumerator DiceRolCoroutine()
    {
        _rigidbody.AddForce(Vector3.up * _force * 2, ForceMode.Impulse);
        _rigidbody.AddTorque(Random.rotation.eulerAngles * _force);
        yield return new WaitForSeconds(3);
        //yield return new WaitUntil(() => _rigidbody.velocity == Vector3.zero);
        DiceResetPosition();
        DiceUpEdgeValue();
        grounded = true;
        
    }

    private void DiceRoll()
    {
        _rigidbody.AddForce(Vector3.up * _force * 2, ForceMode.Impulse);
        _rigidbody.AddTorque(Random.rotation.eulerAngles * _force);
    }

    public void DiceUpEdgeValue()
    {
        float tempMin = 5;
        var edgeValue = 0;
        foreach (var edge in edges)
            if (edge.transform.position.y < tempMin)
            {
                edgeValue = int.Parse(edge.name);
                tempMin = edge.transform.position.y;
            }


        diceValue = 7 - edgeValue;
    }
    
    private void DiceResetPosition()
    {
        transform.DOMove(_resetPoint, 1);
        var diceRotationVector = transform.rotation.eulerAngles;
        transform.DORotate(new Vector3(diceRotationVector.x, 0, diceRotationVector.z), 1);
    }

    #region Events

    [HideInInspector] public UnityEvent OnDiceRoll = new();

    #endregion
}