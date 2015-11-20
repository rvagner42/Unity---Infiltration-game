using UnityEngine;
using System.Collections;

public class OutcomeManager : MonoBehaviour {

	private MainCamera				player;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<MainCamera> ();
		player.Loss += LossScreen;
		player.Win += WinScreen;
	}

	void LossScreen()
	{
		transform.GetChild (1).gameObject.SetActive(true);
	}

	void WinScreen()
	{
		transform.GetChild (2).gameObject.SetActive(true);
	}
}
