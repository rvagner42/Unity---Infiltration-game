using UnityEngine;
using System.Collections;

public class AlarmSystem : MonoBehaviour {

	private MainCamera				player;
	private AudioSource				sound;
	private Color					base_color;
	private bool					alarm_started = false;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<MainCamera> ();
		player.AlarmStart += StartAlarm;
		player.AlarmStop += StopAlarm;
		base_color = transform.GetChild (0).GetComponent<Light> ().color;
		sound = GetComponent<AudioSource> ();
	}

	void StartAlarm()
	{
		if (!alarm_started)
		{
			sound.Play ();
			foreach (Transform child in transform) {
				child.GetComponent<Light> ().color = new Color (1.0f, 0.0f, 0.0f);
			}
			alarm_started = true;
		}
	}

	void StopAlarm()
	{
		if (alarm_started)
		{
			sound.Stop ();
			foreach (Transform child in transform) {
				child.GetComponent<Light> ().color = base_color;
			}
			alarm_started = false;
		}
	}
}
