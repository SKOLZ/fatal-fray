using UnityEngine;
using System.Collections;

public class FatalFrayPanel : MonoBehaviour {

	private Animator anim;

	public void show() {
		gameObject.SetActive (true);
		anim = gameObject.GetComponent<Animator> ();
		anim.Play("Visible");
	}

	public void hide() {
		if (anim == null) return;
		anim.Play("Hidden");
		Invoke ("deactivate", 0.5f);
	}

	public void deactivate() {
		gameObject.SetActive (false);
	}

	public void activate() {
		gameObject.SetActive (true);
	}

}
