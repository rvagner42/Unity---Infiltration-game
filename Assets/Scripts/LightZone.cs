using UnityEngine;
using System.Collections;

public class LightZone : MonoBehaviour {

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "MainCamera")
			collider.GetComponent<MainCamera> ().discretion += 0.12f;
	}
}
