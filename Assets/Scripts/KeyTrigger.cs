using UnityEngine;
using System.Collections;

public class KeyTrigger : MonoBehaviour {

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
			text.GetComponent<UnityEngine.UI.Text> ().text = "Press E to pick up key.";
		}
	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "MainCamera" && Input.GetKeyDown ("e"))
		{
			collider.GetComponent<MainCamera> ().has_key = true;
			Destroy(transform.parent.gameObject);
			triggered = true;
			text.GetComponent<FonduText> ().active = false;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		text.GetComponent<FonduText> ().active = false;
	}
}
