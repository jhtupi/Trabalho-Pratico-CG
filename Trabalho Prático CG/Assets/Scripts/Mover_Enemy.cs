using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Enemy : MonoBehaviour
{
    public float scrollSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += scrollSpeed * new Vector3(0, 0, -1) * Time.deltaTime;
    }
}
