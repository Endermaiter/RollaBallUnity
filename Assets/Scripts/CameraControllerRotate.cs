using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerRotate : MonoBehaviour
{
    public float rotationSpeed;
    public Transform reference;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.RotateAround(reference.transform.position,Vector3.up, rotationSpeed*Time.deltaTime);
        
    }
}