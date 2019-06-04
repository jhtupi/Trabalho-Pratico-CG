using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    public GameObject playerExplosion;

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && this.tag == "Boundary")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            
        }

        Destroy(other.gameObject);

    }
}