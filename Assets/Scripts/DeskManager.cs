using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DeskManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> _desks;
    void Start()
    {
        _desks = GameObject.FindGameObjectsWithTag("Desk").ToList();
        EventManager.OnDiceRolled.AddListener(ManCheck);
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ManCheck()
    {
        foreach (var desk in _desks)
        {
            desk.GetComponent<Desk>().CloseMans(DiceManager.DiceValues);
        }
    }
}
