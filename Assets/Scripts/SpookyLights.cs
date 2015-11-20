using UnityEngine;
using System.Collections;

public class SpookyLights : MonoBehaviour {

	void Start ()
	{
		StartCoroutine (SpookyStuff());
	}
	
	void Update ()
	{
		foreach (Transform child in transform)
		{
			child.GetComponent<Light> ().intensity += 0.5f;
		}
	}

	IEnumerator SpookyStuff()
	{
		for (;;)
		{
			foreach (Transform child in transform)
			{
				child.GetComponent<Light> ().intensity = 0;
			}
			yield return new WaitForSeconds(Random.Range(0.1f, 1.0f));
			foreach (Transform child in transform)
			{
				child.GetComponent<Light> ().intensity = 0;
			}
			yield return new WaitForSeconds(Random.Range(0.1f, 1.0f));
			foreach (Transform child in transform)
			{
				child.GetComponent<Light> ().intensity = 0;
			}
			yield return new WaitForSeconds(Random.Range(1.0f, 4.0f));
		}
	}
}
