using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getlayer : MonoBehaviour
{
    CameraRaycaster cameraRaycaster;
    void Start()
    {
        cameraRaycaster = GetComponent<CameraRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        print(cameraRaycaster.layerHit);
    }
}
