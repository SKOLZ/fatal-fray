using UnityEngine;
using System.Collections;

public class StaminaScript : MonoBehaviour {

	public float maxStamina;
	public float recoveryTime;
	private float currentStamina;
	public int lifeCount;

	public GameManager gameManager;
	private MovementScript moveScript;
	private Rigidbody rigidBody;
	private Animator anim;
	private Vector3 upperRightDeathPoint;
	private Vector3 lowerLeftDeathPoint;
	// Update is called once per frame
	void Start() {
		upperRightDeathPoint = gameManager.getUpperRightDeathPoint();
		lowerLeftDeathPoint = gameManager.getLowerLeftDeathPoint();
		rigidBody = rigidbody;
		anim = GetComponent<Animator> ();
		moveScript = GetComponent<MovementScript> ();
		currentStamina = maxStamina;
	}
	
	public void GetHit(float knockback, float damage, string direction) {
		currentStamina -= damage;
		if (direction == "left") {
			rigidBody.velocity = new Vector3 (knockback, rigidBody.velocity.y, 0f);
		} else if (direction == "right") {
			rigidBody.velocity = new Vector3(-knockback, rigidBody.velocity.y, 0f);
		}

		if (moveScript.GetFacingDirection () == "left") {
			anim.SetBool("getHitL", true);
		} else {
			anim.SetBool("getHitR", true);
		}
		anim.SetBool ("control", false);
		Invoke ("recover", recoveryTime);
	}

	void recover() {
		anim.SetBool ("control", true);
		anim.SetBool ("getHitR", false);
		anim.SetBool ("getHitL", false);
	}

	void loseLife() {
		lifeCount = lifeCount - 1;
		if (lifeCount > 0) {
			respawn();
		}
	}

	void respawn() {
		transform.position = gameManager.getRespawnPoint();
	}

	public bool isEliminated() {
		return lifeCount == 0;
	}

	bool outOfBounds() {
		return (transform.position.y >= upperRightDeathPoint.y) || (transform.position.x >= upperRightDeathPoint.x) || (transform.position.y <= lowerLeftDeathPoint.y) || (transform.position.x <= lowerLeftDeathPoint.x);
	}

	void FixedUpdate() {
		if (outOfBounds ())
			loseLife ();
	}
}
