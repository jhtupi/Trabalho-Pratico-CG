using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorSpawn : MonoBehaviour { 

    public GameObject player, self;


    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        self.GetComponent<Transform>().Rotate(-player.transform.rotation.x, -player.transform.rotation.y, -player.transform.rotation.z, Space.Self);
            
            //rotation.Set(-player.transform.rotation.x, -player.transform.rotation.y, -player.transform.rotation.z, -player.transform.rotation.w);
        
    }
}
