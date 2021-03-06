﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Boundary boundary;
    public float tilt;

    public GameObject shot, bomb;
    public Transform shotSpawn;
    private Quaternion shotRotation;
    public float fireRate;


    private int bombCounter;

    private float nextFire;

    void Start()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
        bombCounter = 3;
    }

    void Update()
    {        
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            shotRotation = new Quaternion(
                shotSpawn.rotation.x - shotSpawn.rotation.x,
                shotSpawn.rotation.y - shotSpawn.rotation.y,
                shotSpawn.rotation.z - shotSpawn.rotation.z,
                shotSpawn.rotation.w - shotSpawn.rotation.w
                );
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotRotation);
            GetComponent<AudioSource>().Play();
        }

        if (Input.GetButton("Fire2") && Time.time > nextFire)
        {

            if (bombCounter > 0)
            {
                shotRotation = new Quaternion(
                shotSpawn.rotation.x - shotSpawn.rotation.x,
                shotSpawn.rotation.y - shotSpawn.rotation.y,
                shotSpawn.rotation.z - shotSpawn.rotation.z,
                shotSpawn.rotation.w - shotSpawn.rotation.w
                );
                nextFire = Time.time + fireRate;
                Instantiate(bomb, (shotSpawn.position + new Vector3(0.0f, 0.0f, 0.9f)), shotRotation);
                bombCounter = bombCounter - 1;
                GetComponent<AudioSource>().Play();
            }
            
            
        }


    }

    public void IncreaseBomb()
    {
        bombCounter = bombCounter + 3;
    }

    void FixedUpdate()
    {
        

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        GetComponent<Rigidbody>().velocity = movement*speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
            GetComponent<Rigidbody>().position.z


        );

        if(moveHorizontal != 0)
        {
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
        }

        if (moveVertical != 0)
        {
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(GetComponent<Rigidbody>().velocity.y * -tilt, 0.0f, 0.0f);
        }

    }


}
