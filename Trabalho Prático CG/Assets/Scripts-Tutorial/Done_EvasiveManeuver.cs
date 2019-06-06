using UnityEngine;
using System.Collections;

public class Done_EvasiveManeuver : MonoBehaviour
{
	public Boundary boundary;
	public float tilt;
	public float dodge;
    public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;

	private float currentSpeed;
	private float targetManeuver;
    private float flagEvasao;

	void Start ()
	{
		currentSpeed = GetComponent<Rigidbody>().velocity.z;
		StartCoroutine(Evade());
	}
	
	IEnumerator Evade ()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true)
		{
            flagEvasao = Random.Range(0, 100);
            if(flagEvasao >= 50) // Evasão horizontal
            {
                targetManeuver = Random.Range(0, dodge) * -Mathf.Sign(transform.position.x);
            }
            else // Evasão vertical
            {
                targetManeuver = Random.Range(0, dodge) * -Mathf.Sign(transform.position.y);
            }
          
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}
	
	void FixedUpdate ()
	{
        if (flagEvasao >= 50) // Evasão horizontal
        {
            float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
                GetComponent<Rigidbody>().position.z
            );
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
        }
        else // Evasão vertical
        {
            float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.y, targetManeuver, smoothing * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, newManeuver, currentSpeed);
            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
                GetComponent<Rigidbody>().position.z
            );
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(GetComponent<Rigidbody>().velocity.y * -tilt, 0, 0);
        }
		
		
		
	}
}
