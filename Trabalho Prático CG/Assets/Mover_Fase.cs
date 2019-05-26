using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Fase : MonoBehaviour
{
    public GameObject fase1, fase2;
    private int flagFase;
    public float distancia;
    
    private void Start()
    {
        flagFase = 1;    
    }
    private void OnTriggerEnter(Collider other)
    {
        if(flagFase == 1)
        {
            //fase1.GetComponent<Transform>().position.Set(fase1.GetComponent<Transform>().position.x,
              //  fase1.GetComponent<Transform>().position.y, fase1.GetComponent<Transform>().position.z + 100.0f);
            //flagFase = 0;
            fase1.transform.position = new Vector3(fase1.GetComponent<Transform>().position.x, fase1.GetComponent<Transform>().position.y, fase1.GetComponent<Transform>().position.z + distancia);
        } else
        {

        }
        
    }
}
