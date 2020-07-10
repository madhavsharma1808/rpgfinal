using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float maxhealth = 100f;
    [SerializeField] float currenthealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float healthAsPercentage()
    {
        return currenthealth / maxhealth;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
