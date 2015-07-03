using UnityEngine;
using System.Collections;

public class HitboxScript : MonoBehaviour {

	public Vector3 localPos;
	public GameObject hitter;

	public float knockback;
	public float verticalFactor;
	public float damage;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag.Equals ("Player") && collider.gameObject != transform.parent.gameObject) {
			string dir = ((collider.transform.position.x - hitter.transform.position.x) > 0) ? "left" : "right";
			StaminaScript otherStamina = collider.GetComponent<StaminaScript> ();
			otherStamina.GetHit (knockback, damage, verticalFactor, dir);
		}
	}

	void Update() {
		transform.localPosition = localPos;
	}
}
