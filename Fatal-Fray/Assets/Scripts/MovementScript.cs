using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	// Use this for initialization
	public string facing;
	public KeyCode leftKey;
	public KeyCode rightKey;
	public KeyCode runKey;
	public KeyCode jumpKey;
	public float minSpeed;
    public float maxSpeed;
	private Rigidbody rigidBody;
    public float speed;
	public float runSpeed;
	public float jumpSpeed;
	public float jumpDelay;
	public Animator anim;
	private int jumpCount = 0;
	public AttackScript attackScript;
	private Vector3 leftVector = new Vector3(0, -90, 0);
	private Vector3 rightVector = new Vector3(0, 90, 0);

	void Start () {
		attackScript = GetComponent<AttackScript> ();
		if (facing.Equals ("left")) {
			transform.eulerAngles = leftVector;
		} else {
			transform.eulerAngles = rightVector;
		}
		rigidBody = rigidbody;
		rigidBody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(rightKey) && CanMove())
		{
			if(Input.GetKey(runKey)) {
				anim.SetBool("running", true);
				anim.SetBool("walking", true);
				rigidBody.velocity = new Vector3(runSpeed, rigidBody.velocity.y, 0f);
			} else {
				anim.SetBool("running", false);
            	anim.SetBool("walking", true);
				rigidBody.velocity = new Vector3(speed, rigidBody.velocity.y, 0f);
			}
			if (facing.Equals ("left")) {
				transform.eulerAngles = rightVector;
				facing = "right";
			}
		} else if (Input.GetKey(leftKey) && CanMove()) {
			
			if(Input.GetKey(runKey)) {
				anim.SetBool("running", true);
				anim.SetBool("walking", true);
				rigidBody.velocity = new Vector3(-runSpeed, rigidBody.velocity.y, 0f);
			} else {
				anim.SetBool("running", false);
            	anim.SetBool("walking", true);
				rigidBody.velocity = new Vector3(-speed, rigidBody.velocity.y, 0f);
			}
			if (facing.Equals ("right")) {
				transform.eulerAngles = leftVector;
				facing = "left";
			}
        }

        if (rigidBody.velocity.sqrMagnitude < minSpeed) {
            rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0f);
            anim.SetBool("walking", false);
			anim.SetBool("running", false);
        }
	}

	void doJump() {
		if (CanMove ()) {
			jumpCount++;
			rigidBody.velocity = new Vector3 (rigidBody.velocity.x, jumpSpeed, rigidBody.velocity.z);
		}
	}

	public void resetJump() {
		jumpCount = 0;
	}

	bool CanMove() {
		return attackScript.NotAttacking () && anim.GetBool("control");
	}

	void Update() {
		if (Input.GetKeyDown (jumpKey) && jumpCount < 1) {
			anim.SetBool ("jumping", true);
			Invoke("doJump", jumpDelay);
		}
	}

	public string GetFacingDirection() {
		return facing;
	}
}
