using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

	// Use this for initialization
    public Animator anim;

	// Update is called once per frame
	void FixedUpdate () {
        if ((Input.GetKeyDown(KeyCode.A))) {
            anim.SetBool("shoot", true);
        } else {
            anim.SetBool("shoot", false);

        }
    }
}
