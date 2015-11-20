using UnityEngine;
using System.Collections;

public class DoorSlider : MonoBehaviour {
	
	void Start()
	{
		transform.parent.GetChild(2).GetComponent<DoorTrigger> ().OpenDoor += InitiateDoorSlide;
	}

	void InitiateDoorSlide()
	{
		StartCoroutine (DoorSlide());
	}

	IEnumerator DoorSlide()
	{
		GetComponent<AudioSource> ().Play ();
		while (transform.localPosition.x < -0.2)
		{
			transform.localPosition = transform.localPosition + (new Vector3(0.01f, 0.0f, 0.0f));
			yield return new WaitForSeconds(0.02f);
		}
		GetComponent<AudioSource> ().Stop ();
	}
}
