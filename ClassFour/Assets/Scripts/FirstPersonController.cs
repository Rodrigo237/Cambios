﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed;
    public float speedRotation;
    public Transform transformCamera;
    private Rigidbody fpsRB;
    public float jumpForce;
    public Shooter shooter;
    public GameObject gun;
    public bool isOnTheGround = true;
    public Camera cameraTransform;
    public float playerlife = 5;
    public GameObject Screen;
    public GameObject Crosshair;
    private StateGame state = new StateGame();
    float angleX;
    float InputY;
     void Start()
    {
        fpsRB = GetComponent<Rigidbody>();
        Screen = GetComponent<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {
            // fpsRB.AddForce(new Vector3(0.0f, 7.0f, 0f), ForceMode.VelocityChange);
            fpsRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
        }
        
        fpsRB.velocity = (transform.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime) + (transform.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime + (Vector3.up * fpsRB.velocity.y));
      //  transform.Translate((Vector3.forward*speed*Input.GetAxis("Vertical")*Time.deltaTime)+(Vector3.right*speed*Input.GetAxis("Horizontal")*Time.deltaTime));


        transform.Rotate(Vector3.up * speedRotation * Time.deltaTime*Input.GetAxis("Mouse X"));

        angleX += -speedRotation * Time.deltaTime * Input.GetAxis("Mouse Y");
        angleX = Mathf.Clamp(angleX, -90f, 90f);

        cameraTransform.transform.localRotation = Quaternion.Euler(angleX, 0f, 0f);


    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Gun") {
            Destroy(collision.gameObject);
            gun.SetActive(true);
            shooter.isActive = true;
            Crosshair.SetActive(true);
        }

        if (collision.gameObject.tag == "Ground") {
            isOnTheGround = true;
        }

        if (collision.gameObject.tag == "Enemy") {
            playerlife -= 1;
            state.die();
        }
    }

     void OnCollisionExit(Collision collision)
    {
        
    }
}
