using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class cube : MonoBehaviour
{

    public void Awake()
    {
    }
    [YarnCommand("agreed")]
    void Agreed()
    {
        Debug.Log("Agreed!");
    }
}
