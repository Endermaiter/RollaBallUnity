using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascensor : MonoBehaviour
{

    public GameObject[] waypoints;
    public float platformSpeed = 2;
    public int waypointsIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,waypoints[waypointsIndex].transform.position) < 0.1f){

            waypointsIndex++;

            if(waypointsIndex >= waypoints.Length){
                waypointsIndex = 0;
            }   


        }   

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsIndex].transform.position, platformSpeed*Time.deltaTime);

    }


}