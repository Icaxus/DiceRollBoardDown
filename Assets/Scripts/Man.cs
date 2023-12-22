using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Man : MonoBehaviour
{
    [SerializeField] private string _manId;
    [SerializeField] private float _manDefaultRotation = 45f;
    [SerializeField] private float _manDefaultRotationRotated = -45f;
    private Vector3 _manEulers;
    private TextMeshPro _tmpId;
    // Start is called before the first frame update
    void Start()
    {
        _tmpId = this.GetComponentInChildren<TextMeshPro>();
        _tmpId.text = _manId;
        _manEulers = transform.rotation.eulerAngles;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseMan()
    {
        transform.DORotate(new Vector3(_manEulers.x,_manEulers.y,_manDefaultRotationRotated),1);
    }

    void ManCloseCheck(int dice1, int dice2, int diceSum)
    {
        if(!ManClosable())
        {
            Debug.Log("Man've already closed.");
            return;
        }
        
        int manId = Int32.Parse(_manId);
        if (dice1 == dice2 && diceSum <= 6)
        {
            if (diceSum == manId)
            {
                CloseMan();
            }
        }
        
        if (diceSum >= 7 && diceSum == manId)
        {
            if(ManClosable())
                CloseMan();
            return;
        }
        else if(manId == dice1)
        {
            CloseMan();
        }
        else if (manId == dice2)
        {
            
        }
    }

    public bool ManClosable()
    {
        return _manEulers.z == -45f;
    }
}
