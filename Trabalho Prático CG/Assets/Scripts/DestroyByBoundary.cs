using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    public GameObject playerExplosion;
    //private GameController gameController;

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && this.tag == "Boundary")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            
        }
        if(other.tag == "Boss")
        {
            return;
        }

        Destroy(other.gameObject);
        

    }
}