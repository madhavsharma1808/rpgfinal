﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursortexture : MonoBehaviour
{
    [SerializeField] Texture2D walkcursor;
    [SerializeField] Texture2D enemycursor;
    [SerializeField] Texture2D unknowncursor;
    [SerializeField] Vector2 cursorhotspot = new Vector2(96, 96);

    Texture2D currentcursor;
    CameraRaycaster cameraRaycaster;
    // Start is called before the first frame update
    void Start()
    {
        cameraRaycaster = GetComponent<CameraRaycaster>();
        cameraRaycaster.layerchangeobservor += ondeleatecall;
    }
    
    // Update is called once per frame
    void ondeleatecall(Layer newlayer)
    {
        print("hello2");
        switch(newlayer)
        {
            case Layer.Walkable:
                Cursor.SetCursor(walkcursor, cursorhotspot, CursorMode.Auto);
                break;
            case Layer.Enemy:
                Cursor.SetCursor(enemycursor, cursorhotspot, CursorMode.Auto);
                
                break;
            case Layer.RaycastEndStop:
                Cursor.SetCursor(unknowncursor, cursorhotspot, CursorMode.Auto);
                break;
        }
        
    }
       
}
