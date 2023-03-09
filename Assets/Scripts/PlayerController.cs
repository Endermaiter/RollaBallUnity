using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;

    private Rigidbody rb;

    private float movementX;
    private float movementY;
    private float movementZ;
    private Collider ascensor1;
    private Collider ascensor2;

    private int coinCount;

    // Start is called before the first frame update
    void Start()
    {
        // instanciando el objeto que contiene este script
        // la bola
        rb = GetComponent<Rigidbody>();
        Debug.Log("Estoy en Start");
    }

    /**
     *  Evento Input System
     **/
    
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
        // mensaje para la consola del Unity
        //Debug.Log("Estoy en OnMove x: " + movementX);
    }

    private void FixedUpdate()
    {
        // para el teclado
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        // recogemos los datos del acelerometro
        Vector3 dir = Vector3.zero;
        dir.x = -Input.acceleration.y;
        dir.z = Input.acceleration.x;
        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        
        dir *= Time.deltaTime;
        transform.Translate(dir * speed);
    }

    void Update()
    {
        //ASCENSOR 1
        if (ascensor1.gameObject.CompareTag("Ascensor1"))
        {
            transform.position = new Vector3(-86, 22, -16);
            transform.localScale = new Vector3(2,2,2);
        }
        
        //ASCENSOR 2
        
        if (ascensor2.gameObject.CompareTag("Ascensor2"))
        {
            transform.position = new Vector3(-86, 33, 16);
            transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        }
    }

    private void OnTriggerEnter(Collider coin)
    {
        if (coin.gameObject.CompareTag("PickUp"))
        {
            coinCount++;
            Debug.Log("Score: " + coinCount);
            coin.gameObject.SetActive(false);
            if (coinCount == 1)
            {
                speed = speed * 3;
            }
        }
    }

}