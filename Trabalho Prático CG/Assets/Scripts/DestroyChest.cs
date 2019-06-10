using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChest : MonoBehaviour
{
   
   
    public GameObject self;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
 

        if (other.tag == "Player") 
        {
            Destroy(self);
        }



    }
}
