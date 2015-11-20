using UnityEngine;
using System.Collections;

public class SmokeZone : MonoBehaviour {

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "MainCamera")
			collider.GetComponent<MainCamera> ().discretion -= 0.8f;
	}
}
