using UnityEngine;
using System.Collections;

public class Gauge : MonoBehaviour {

	private MainCamera				player;
	private UnityEngine.UI.Image	img;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<MainCamera> ();
		img = transform.GetChild(1).GetComponent<UnityEngine.UI.Image> ();
	}
	
	void Update () {
		if (player.discretion >= 75.0f)
			img.color = new Color (1.0f, 0.0f, 0.0f);
		else
			img.color = new Color (1.0f, 1.0f, 1.0f);

		img.fillAmount = player.discretion * 0.0096f;
	}
}
