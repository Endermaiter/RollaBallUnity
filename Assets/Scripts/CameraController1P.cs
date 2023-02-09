using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1P : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("STARTING");
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position;


    }
}