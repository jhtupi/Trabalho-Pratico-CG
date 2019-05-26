using UnityEngine;
using System.Collections;

public class PlayerScroller : MonoBehaviour
{
	public float scrollSpeed;
	
	void Update ()
	{
        //transform.position += transform.TransformDirection(Vector3.forward) * scrollSpeed * Time.deltaTime;
        transform.position += scrollSpeed * new Vector3(0, 0, 1)* Time.deltaTime;



    }
}