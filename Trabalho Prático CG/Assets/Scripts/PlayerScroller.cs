using UnityEngine;
using System.Collections;

public class PlayerScroller : MonoBehaviour
{
	public float scrollSpeed;
	
	void Update ()
	{
        transform.position += scrollSpeed * new Vector3(0, 0, 1)* Time.deltaTime;

    }

    public void stop()
    {
        scrollSpeed = 0.0f;
    }
}