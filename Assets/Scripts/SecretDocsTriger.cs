using UnityEngine;
using System.Collections;

public class SecretDocsTriger : MonoBehaviour {

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
			text.GetComponent<UnityEngine.UI.Text> ().text = "Press E to get secret docs.";
		}
	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "MainCamera" && Input.GetKeyDown ("e"))
		{
			collider.GetComponent<MainCamera> ().has_docs = true;
			text.GetComponent<FonduText> ().active = false;
			triggered = true;
			Destroy (transform.parent.gameObject);
		}
	}

	void OnTriggerExit(Collider collider)
	{
		text.GetComponent<FonduText> ().active = false;
	} 
}
