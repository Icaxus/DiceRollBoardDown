using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<Dice> dices;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            //Debug.Log("Space pressed");
            //_rigidbody.AddExplosionForce(5f, transform.position, 5.0f, 3.0f);
            foreach (var dice in dices)
            {
                // dice._rigidbody.AddForce(Vector3.up * _force * 2, ForceMode.Impulse);
                // dice._rigidbody.AddTorque(Random.rotation.eulerAngles * _force);
            }
            
        }
    }

    void GetDiceValues()
    {
        
    }
}
