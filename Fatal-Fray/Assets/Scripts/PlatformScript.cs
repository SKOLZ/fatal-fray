using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	void OnCollisionExit(Collision col) {
	}

	void OnCollisionEnter(Collision col) {
		if (col.collider.gameObject.tag.Equals ("Player")) {
			col.collider.GetComponent<Animator> ().SetBool ("jumping", false);
			col.collider.GetComponent<MovementScript> ().resetJump ();
		}
	}
}
