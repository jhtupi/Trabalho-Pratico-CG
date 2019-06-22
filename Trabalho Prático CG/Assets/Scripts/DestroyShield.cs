using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DestroyShield : MonoBehaviour
{

  
    public GameObject self;
    


    void OnTriggerEnter(Collider other)
    {


        
            if (other.tag == "Enemy"  ) // ou Tiro do Boss
            {
                self.SetActive(false);

            }
            else
            {
                return;
            }

        


    }
   

}
