using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Fase : MonoBehaviour
{
    public GameObject fase1, fase2, boundary, self;
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
            fase1.transform.position = new Vector3(fase1.GetComponent<Transform>().position.x, fase1.GetComponent<Transform>().position.y, fase1.GetComponent<Transform>().position.z + distancia);
            moverObjetos();
            flagFase = 0;
        } else
        {
            fase2.transform.position = new Vector3(fase2.GetComponent<Transform>().position.x, fase2.GetComponent<Transform>().position.y, fase2.GetComponent<Transform>().position.z + distancia);
            flagFase = 1;
            moverObjetos();
        }
    }
    private void moverObjetos()
    {
        boundary.transform.position = new Vector3(boundary.GetComponent<Transform>().position.x, boundary.GetComponent<Transform>().position.y, boundary.GetComponent<Transform>().position.z + (distancia/2));
        self.transform.position = new Vector3(self.GetComponent<Transform>().position.x, self.GetComponent<Transform>().position.y, self.GetComponent<Transform>().position.z + (distancia/2));

    }
}
