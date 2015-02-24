using UnityEngine;
using System.Collections;

public class MeleeAttackScript : AttackScript {

	public KeyCode attack1;
	public KeyCode attack2;
	public KeyCode attack3;

	public float attack1Delay; 
	public float attack2Delay;
	public float attack3Delay;

	public GameObject[] hitboxes;

	public float[] hitboxDelays; 

	public Animator anim;

	void Start() {
		foreach (GameObject hitbox in hitboxes) { 
			hitbox.collider.enabled = false;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (attack1)) {
			doAttack1();
		} else if (Input.GetKeyDown (attack2)) {
			doAttack2();
		} else if (Input.GetKeyDown (attack3)) {
			doAttack3();
		}
	}

	void doAttack1() {
		anim.SetBool("attack1", true);
		Attack ();
		Invoke ("activeHitbox1", hitboxDelays[0]);
		Invoke ("stopAttack1", attack1Delay);
	}

	void activeHitbox1() {
		hitboxes[0].collider.enabled = true;
	}

	void activeHitbox2() {
		hitboxes[1].collider.enabled = true;
	}

	void activeHitbox3() {
		hitboxes[2].collider.enabled = true;
	}

	void stopAttack1() {
		hitboxes[0].collider.enabled = false;
		anim.SetBool ("attack1", false);
		StopAttack ();
	}


	void doAttack2() {
		anim.SetBool("attack2", true);
		Attack ();
		Invoke ("activeHitbox2", hitboxDelays[1]);
		Invoke ("stopAttack2", attack2Delay);
	}

	void stopAttack2() {
		hitboxes[1].collider.enabled = false;
		anim.SetBool ("attack2", false);
		StopAttack ();
	}

	void stopAttack3() {
		hitboxes[2].collider.enabled = false;
		anim.SetBool ("attack3", false);
		StopAttack ();
	}

	void doAttack3() {
		anim.SetBool("attack3", true);
		Attack ();
		Invoke ("activeHitbox3", hitboxDelays[2]);
		Invoke ("stopAttack3", attack3Delay);
	}
}
