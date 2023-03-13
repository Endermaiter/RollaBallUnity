using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
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
    public TextMeshProUGUI coinCountText;
    public TextMeshProUGUI winnerText;
    
    public TextMeshProUGUI timer;
    private float segs;
    
    public String referenceObject;
    public GameObject[] ending;

    // Start is called before the first frame update
    void Start()
    {
        // instanciando el objeto que contiene este script
        // la bola
        rb = GetComponent<Rigidbody>();
        coinCount = 0;
        segs = 0;
        setCoinCountText();
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

        segs = segs + 1 * Time.deltaTime;
        timer.text = "Tiempo: " + segs.ToString("00");
    }

    private Boolean sem1 = true;
    private Boolean sem2 = true;
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("PickUp"))
        {
            coinCount++;
            setCoinCountText();
            col.gameObject.SetActive(false);
            if (coinCount == 1)
            {
                speed = speed * 3;
            }
        }
        
        //ASCENSOR 1
        
        if (col.gameObject.CompareTag("Ascensor1"))
        {
            if (sem1)
            {
                transform.position = new Vector3(-86, 22, -16);
                transform.localScale = new Vector3(2,2,2);
                
                sem1 = false;
            }
        }
        
        //ASCENSOR 2
        
        if (col.gameObject.CompareTag("Ascensor2"))
        {
            if(sem2)
            {
                transform.position = new Vector3(-86, 33, 16);
                transform.localScale = new Vector3(0.5f,0.5f,0.5f);
                sem2 = false;
            }
        }
        
        if (col.gameObject.CompareTag("EndLine"))
        {
            setWinnerText();
            Time.timeScale = 0;
        }
        if (col.gameObject.CompareTag("Finish"))
        {
            col.gameObject.SetActive(false);
            ending[1].SetActive(true);
            ending[0].gameObject.SetActive(true);
                
        }
    }

    void setCoinCountText()
    {
        coinCountText.gameObject.SetActive(true);
        coinCountText.text = "Monedas:" + coinCount + "/10";
    }

    void setWinnerText()
    {
        winnerText.text = "Felicidades " + referenceObject +", HAS GANADO";
    }

}