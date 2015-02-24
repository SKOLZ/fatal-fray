using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

	private bool attacking = false;

	public bool NotAttacking() {
		return !attacking;
	}

	public void Attack() {
		attacking = true;
	}

	public void StopAttack() {
		attacking = false;
	}
}
