using UnityEngine;
using System.Collections;

public class CamZone : MonoBehaviour {

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "MainCamera")
			collider.GetComponent<MainCamera> ().discretion += 1.0f;
	}
}
