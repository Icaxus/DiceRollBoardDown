using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Man : MonoBehaviour
{
    [SerializeField] private string _manId;

    private TextMeshPro _tmpId;
    // Start is called before the first frame update
    void Start()
    {
        _tmpId = this.GetComponentInChildren<TextMeshPro>();
        _tmpId.text = _manId;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
