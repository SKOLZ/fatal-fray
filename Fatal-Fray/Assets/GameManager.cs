using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public StaminaScript[] players;
	public Vector3[] respawnPoints;
	public Vector3 upperRightDeathPoint;
	public Vector3 lowerLeftDeathPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector3 getRespawnPoint() {
		return respawnPoints[Random.Range(0, respawnPoints.Length)];
	}

	public Vector3 getUpperRightDeathPoint() {
		return upperRightDeathPoint;
	}

	public Vector3 getLowerLeftDeathPoint() {
		return lowerLeftDeathPoint;
	}
}
