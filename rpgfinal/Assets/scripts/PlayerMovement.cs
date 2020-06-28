using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float minimumoffsetdistance=0.2f;
    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
    public float awaycurserdistance;
    bool isdirect = false;
    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            isdirect = !isdirect;
        }    
        if(isdirect)
            keyboardmovement();
        else
            cursormovement();
        
    }
    private void keyboardmovement()

    {
        print("direct");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool crouch = Input.GetKey(KeyCode.C);

        // calculate move direction to pass to character
        if (Camera.main != null)
        {
            // calculate camera relative direction to move:
            Vector3 m_CamForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 m_Move = v * m_CamForward + h * Camera.main.transform.right;
            m_Character.Move(m_Move, false, false);
        }
       
    }

    private void cursormovement()
    {
        print("indirect");
        if (Input.GetMouseButton(0)) 
        {
            switch (cameraRaycaster.layerHit)
            {
                case Layer.Walkable:
                    currentClickTarget = cameraRaycaster.hit.point;
                    break;
                case Layer.Enemy:
                    print("enemy");//will not move for now to enemy
                    break;
                case Layer.RaycastEndStop:
                    print("unexpected area");
                    break;
            }
            print( cameraRaycaster.layerHit);

        }
        //error in player facingdirection
         Vector3 distancetobecovered = currentClickTarget - transform.position;
        if (distancetobecovered.magnitude >= minimumoffsetdistance)
        {
            m_Character.Move(distancetobecovered, false, false);
        }
        else
        {
            m_Character.Move(Vector3.zero, false, false);
        }
    }
}

