using System.Collections;
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
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            
        }

        if (Input.GetButton("Fire2") && Time.time > nextFire)
        {
            if (bombCounter > 0)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bomb, (shotSpawn.position + new Vector3(0.0f, 0.0f, 0.9f)), shotSpawn.rotation);
                bombCounter = bombCounter - 1;
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
