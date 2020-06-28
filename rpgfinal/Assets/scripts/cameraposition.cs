using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraposition : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {

        transform.position = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
