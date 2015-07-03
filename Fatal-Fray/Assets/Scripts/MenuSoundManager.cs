using UnityEngine;
using System.Collections;

public class MenuSoundManager : MonoBehaviour {

	public AudioClip buttonHighlighted;
	public AudioClip buttonClicked;

	public void playClick() {
		audio.clip = buttonClicked;
		audio.Play ();
	}

	public void playHighlighted() {
		audio.clip = buttonHighlighted;
		audio.Play ();
	}
	                             
}
