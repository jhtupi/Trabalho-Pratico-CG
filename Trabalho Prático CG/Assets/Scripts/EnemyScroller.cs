using UnityEngine;
using System.Collections;

public class EnemyScroller : MonoBehaviour
{
	public float scrollSpeed;
	
	void Update ()
	{
        transform.position += scrollSpeed * new Vector3(0, 0, 1)* Time.deltaTime;
        //transform.position = new Vector3(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y, this.GetComponent<Transform>().position.z * Time.deltaTime * scrollSpeed);



    }
}