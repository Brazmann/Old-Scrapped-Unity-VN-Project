
using System.Collections;
using UnityEngine;

namespace Yarn.Unity.Example {
    /// attached to the non-player characters, and stores the name of the Yarn
    /// node that should be run when you talk to them.

    public class Student : MonoBehaviour {

        public bool lookedAt = false;

        public string characterName = "";

        public string talkToNode = "";

        [Header("Optional")]
        public YarnProgram scriptToLoad;

        void Start () {
            if (scriptToLoad != null) {
                DialogueRunner dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
                dialogueRunner.Add(scriptToLoad);                
            }
        }

        void LookedAt() 
            { //Should probably find a way to just have the coroutine be activated by the raycast directly
            lookedAt = true;
            }
    }
}
