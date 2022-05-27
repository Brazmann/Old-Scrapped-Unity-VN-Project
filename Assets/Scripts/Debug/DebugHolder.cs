using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugHolder : MonoBehaviour
{ 
    public bool debugEnabled = false;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F4))
        {
            debugEnabled = true;
        }else if(Input.GetKeyDown(KeyCode.F6))
        {
            debugEnabled = false;
        }
    }

    //lol
}
