using UnityEngine;
using System.Collections;

public class LaserSwitch : MonoBehaviour {

	private GameObject		text;
	private bool			triggered = false;
	
	void Start()
	{
		text = GameObject.FindGameObjectWithTag ("HelpText");
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "MainCamera" && triggered == false)
		{
			text.GetComponent<FonduText> ().active = true;
			text.GetComponent<FonduText> ().alpha = 0.0f;
			text.GetComponent<UnityEngine.UI.Text> ().text = "Press E to deactivate the lasers.";
		}
	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "MainCamera" && Input.GetKeyDown ("e"))
		{
			text.GetComponent<FonduText> ().active = false;
			triggered = true;
			transform.parent.GetChild (0).gameObject.SetActive (false);
		}
	}
	
	void OnTriggerExit(Collider collider)
	{
		text.GetComponent<FonduText> ().active = false;
	}
}
