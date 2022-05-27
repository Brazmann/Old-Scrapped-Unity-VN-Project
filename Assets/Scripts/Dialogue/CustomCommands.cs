using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CustomCommands : MonoBehaviour
{

    public DialogueRunner dialogueRunner;
    public GameObject head;
    public string cameraTarget;


     public void Awake() {

        //Register list of commands
        dialogueRunner.AddCommandHandler("debug_log", DebugLog);
        dialogueRunner.AddCommandHandler("commandtemplate", MethodTemplate);
        dialogueRunner.AddCommandHandler("camera_look", CameraLook);
        dialogueRunner.AddCommandHandler("camera_return", CameraReturn);
    }

    private void MethodTemplate(string[] parameters)
    {
        
    }

    private void DebugLog(string[] parameters) {
         Debug.Log(parameters[0]);
    }
    private void CameraLook(string[] parameters) {

            cameraTarget = parameters[0];
            GameObject.Find("CameraView").GetComponent<MoveCamera>().CameraLookAtTarget();
    }
    
    private void CameraReturn(string[] parameters)
    {
            GameObject.Find("CameraView").GetComponent<MoveCamera>().CameraReturn();
    }
}