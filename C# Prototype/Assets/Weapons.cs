using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //at start, remove the 
    }

    // Update is called once per frame
    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TurnManager.SwitchTurn();
        }
        
        // if shot, remove ability to shoot and trigger instance of turnmanager
    }
}
