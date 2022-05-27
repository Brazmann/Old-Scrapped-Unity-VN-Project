using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public Transform player;
    public bool cameraFree;

    private void Start()
    {
        cameraFree = true;
    }

    private void Update()
    {
        if(cameraFree == true)
        {
                    transform.position = player.transform.position;
        }
    }

    public void CameraLookAtTarget() 
        {  
         string targetName = GameObject.Find("CommandHandler").GetComponent<CustomCommands>().cameraTarget;
         GameObject target = GameObject.Find(targetName);

         //Log an error if we can't find it
         if (target == null) {
            Debug.LogError($"Cannot make camera look at {targetName}:" + 
                "cannot find target");
            return;
         }

         //Make the camera look at the target
         cameraFree = false;
         this.gameObject.transform.LookAt(target.transform);
    }

    public void CameraReturn()
    {
        cameraFree = true;
    }



}
