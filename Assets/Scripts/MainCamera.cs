using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	private CharacterController		controller;
	private AudioSource[]			sounds;
	private Vector3					direction = Vector3.zero;
	private float					rot_y = 0.0f;
	private float					rot_x = 0.0f;

	private float					speed;

	private bool					game_ended = false;

	public float					walk_speed;
	public float					run_speed;
	public float					sensibility;
	[HideInInspector]public float	discretion = 0.0f;
	[HideInInspector]public bool	has_key = false;
	[HideInInspector]public bool	has_docs = false;


	public delegate	void			Outcome();
	public event Outcome			Loss;
	public event Outcome			Win;

	public delegate void			Alarm();
	public event Alarm				AlarmStart;
	public event Alarm				AlarmStop;

	void Start ()
	{
		controller = GetComponent<CharacterController> ();
		sounds = GetComponents<AudioSource> ();
		speed = walk_speed;
		StartCoroutine (LowerDiscretion());
		sounds [1].Play ();

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update ()
	{
		if (!game_ended)
			MoveCam ();
		if (discretion >= 75.0)
		{
			if (!sounds[1].isPlaying)
				sounds[1].Play();
			if (sounds[0].isPlaying)
				sounds[0].Stop();
			AlarmStart ();
		}
		if (discretion < 75.0f)
		{
			if (sounds[1].isPlaying)
				sounds[1].Stop();
			if (!sounds[0].isPlaying)
				sounds[0].Play();
			AlarmStop ();
		}
		if (discretion >= 100.0f)
		{
			Loss ();
			StopCoroutine (LowerDiscretion());
			StartCoroutine (Reload ());
			game_ended = true;
		}
		if (has_docs)
		{
			Win();
			StopCoroutine (LowerDiscretion());
			StartCoroutine (Reload ());
			game_ended = true;
		}
	}

	void LateUpdate()
	{
		controller.SimpleMove (direction.normalized * speed * Time.deltaTime);
		direction = Vector3.zero;
	}

	void MoveCam()
	{
		if (Input.GetKey ("w"))
			direction += transform.forward;
		if (Input.GetKey ("s"))
			direction += -transform.forward;
		if (Input.GetKey ("d"))
			direction += transform.right;
		if (Input.GetKey ("a"))
			direction += -transform.right;
		if (Input.GetKeyDown ("left shift") && (Input.GetKey ("w") || Input.GetKey ("a") || Input.GetKey ("s") || Input.GetKey ("d")))
			StartRunning ();
		if (Input.GetKeyUp ("left shift"))
			StopRunning ();

		rot_x += Input.GetAxis ("Mouse X") * speed * 2.0f * Time.deltaTime;
		rot_y += Input.GetAxis ("Mouse Y") * speed * 2.0f * Time.deltaTime;
		rot_y = Mathf.Clamp (rot_y, -80, 80);
		transform.localEulerAngles = new Vector3 (-rot_y, rot_x, 0);
	}

	void StartRunning()
	{
		if (speed != run_speed)
		{
			speed = run_speed;
			StartCoroutine (RaiseDiscretion ());
			if (!sounds [2].isPlaying)
				sounds [2].Play ();
		}
	}

	void StopRunning()
	{
		if (speed != walk_speed)
		{
			speed = walk_speed;
			StopCoroutine (RaiseDiscretion ());
			if (sounds [2].isPlaying)
				sounds [2].Stop ();
		}
	}

	IEnumerator RaiseDiscretion()
	{
		for (;;)
		{
			if (discretion < 100.0f && speed == run_speed)
				discretion += 5.0f;
			yield return new WaitForSeconds(0.5f);
		}
	}

	IEnumerator LowerDiscretion()
	{
		for (;;)
		{
			if (discretion > 0.0f && speed == walk_speed)
				discretion -= 0.2f;

			yield return new WaitForSeconds(0.05f);
		}
	}

	IEnumerator Reload()
	{
		foreach (AudioSource s in sounds)
		{
			if (s.isPlaying)
				s.Stop ();
		}
		yield return new WaitForSeconds (4.4f);
		Application.LoadLevel (Application.loadedLevel);
	}
}
