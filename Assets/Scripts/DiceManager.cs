using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class DiceManager : Singleton<DiceManager>
{
    private bool _rolling = false;
    public static List<int> _diceValues;

    public static List<int> DiceValues
    {
        get { return _diceValues; }
    }
    
    [SerializeField] private List<Dice> dices;
    
    // Start is called before the first frame update
    void Start()
    {
        
        foreach (var dice in GameObject.FindGameObjectsWithTag("Dice"))
        {
            dices.Add(dice.GetComponent<Dice>());
        }
        _diceValues = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_rolling)
        {
            _rolling = true;
            StartCoroutine(RollTheDicesCoroutine());
        }
    }


    private IEnumerator RollTheDicesCoroutine()
    {
        foreach (var dice in dices)
        {
            dice.Rigidbody.AddForce(Vector3.up * dice.Force * 2, ForceMode.Impulse);
            dice.Rigidbody.AddTorque(Random.rotation.eulerAngles * dice.Force);
        }
        
        yield return new WaitForSeconds(2.5f);
        DicesResetPosition();
        GetDicesUpEdgeValues();
        _rolling = false;
        EventManager.OnDiceRolled.Invoke();
    }

    private void DicesResetPosition()
    {
        foreach (var dice in dices)
        {
            dice.transform.DOMove(dice.ResetPoint, 0.5f);
            var diceRotationVector = dice.transform.rotation.eulerAngles;
            dice.transform.DORotate(new Vector3(diceRotationVector.x, 0, diceRotationVector.z), 0.5f);
        }
    }

    public void GetDicesUpEdgeValues()
    {
        _diceValues.Clear();
        int diceSum = 0;
        foreach (var dice in dices)
        {
            _diceValues.Add(dice.DiceUpEdgeValue());
            diceSum += dice.DiceUpEdgeValue();
        }
        _diceValues.Add(diceSum);
        

    }
    
}
