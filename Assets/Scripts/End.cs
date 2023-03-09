using System;
using UnityEngine;
using UnityEngine.UI;

    public class End : MonoBehaviour
    {
        public String referenceObject;
        
        private void Start()
        {
           
        }
        public void OnTriggerEnter(Collider endLine)
        {
            if (endLine.gameObject.CompareTag("EndLine"))
            {
                Debug.Log("Felicidades, ganaste " + referenceObject);
                Time.timeScale = 0;
            }
        }
    }