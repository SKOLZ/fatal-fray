using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	// Use this for initialization
    public float minSpeed;
    public float maxSpeed;
    public float speed;
    public Animator anim;
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("moving", true);
            rigidbody.velocity = new Vector3(speed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            anim.SetBool("moving", true);
            rigidbody.velocity = new Vector3(-speed, 0, 0);
        }

        if (rigidbody.velocity.sqrMagnitude < minSpeed) {
            rigidbody.velocity = Vector3.zero;
            anim.SetBool("moving", false);
        } else {
            anim.SetBool("moving", true);
        }
	}
}
