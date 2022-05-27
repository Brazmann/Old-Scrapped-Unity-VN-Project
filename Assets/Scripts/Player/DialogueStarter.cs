using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using Yarn.Unity.Example;

public class DialogueStarter : MonoBehaviour {

     float maxDistance = 10;
     public bool isLooking;
     public Text display_Text;
     public float interactionRadius;
     public DebugHolder dH;
     public PlayerControls playerControls;

    private void Awake()
    {
      playerControls = new PlayerControls();
      playerControls.Player.Interaction.performed += _ => CheckForNearbyStudent();
    }


            public void CheckForNearbyStudent()
            {
            var allParticipants = new List<NPC> (FindObjectsOfType<NPC> ());
            var target = allParticipants.Find (delegate (NPC p) {
                return string.IsNullOrEmpty (p.talkToNode) == false && // has a conversation node?
                (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false) && // is there already dialogue running?
                (p.lookedAt) == true && //is it being looked at by the player?
                (p.transform.position - this.transform.position)// is it in range?
                .magnitude <= interactionRadius;
            });
            if (target != null) {
                // Kick off the dialogue at this node.
                FindObjectOfType<DialogueRunner> ().StartDialogue (target.talkToNode);
            }
        }


    void FixedUpdate()
     {   //This system hits the student with a raycast, which causes the student to run a chunk of code that changes it's "lookedAt" bool to true, which is then checked when starting dialogue.
         RaycastHit hit;
         // if raycast hits, it checks if it hit an object with the tag Student
         if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) && hit.collider.gameObject.CompareTag("Student"))
         {
             hit.transform.SendMessage ("LookedAt");
             isLooking = true;
        }else{
            isLooking = false;
        }
        if(dH.debugEnabled == true)
        { 
         display_Text.enabled = true;
         display_Text.text = "Looking:" + isLooking.ToString();
        }
        else
        {
            display_Text.enabled = false;
        }
     }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
