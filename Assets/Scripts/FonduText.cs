using UnityEngine;
using System.Collections;

public class FonduText : MonoBehaviour {

	private UnityEngine.UI.Text		text;
	[HideInInspector]public float	alpha;
	[HideInInspector]public bool	active = false;

	void Start ()
	{
		text = GetComponent<UnityEngine.UI.Text> ();
		alpha = text.color.a;
	}

	void Update ()
	{
		if (active == true && alpha < 1.0f)
			alpha += 0.02f;
		else if (alpha > 0.0f)
			alpha -=0.02f;
		text.color = new Color (text.color.r, text.color.g, text.color.b, alpha);
	}
}
