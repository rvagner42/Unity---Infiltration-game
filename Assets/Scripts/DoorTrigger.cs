using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	public delegate void DoorEvent();
	public event DoorEvent OpenDoor;

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
			if (collider.GetComponent<MainCamera> ().has_key == true)
				text.GetComponent<UnityEngine.UI.Text> ().text = "Press E to unlock door.";
			else
				text.GetComponent<UnityEngine.UI.Text> ().text = "You need a key to open the door.";
		}
	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "MainCamera" && Input.GetKeyDown ("e"))
		{
			if (collider.GetComponent<MainCamera> ().has_key == true)
			{
				transform.parent.GetChild (0).GetChild(0).gameObject.SetActive (false);
				transform.parent.GetChild (0).GetChild(1).gameObject.SetActive (true);
				OpenDoor();
				collider.GetComponent<MainCamera> ().has_key = false;
				triggered = true;
				text.GetComponent<FonduText> ().active = false;
			}
			else
				GetComponent<AudioSource> ().Play ();
		}
	}

	void OnTriggerExit(Collider collider)
	{
		text.GetComponent<FonduText> ().active = false;
	}
}
