using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "MainCamera")
			collider.GetComponent<MainCamera> ().discretion = 100.0f;
	}
}
