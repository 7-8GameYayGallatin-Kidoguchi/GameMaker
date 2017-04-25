using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFruit : MonoBehaviour {

	public GameObject fruit;
	public GameObject gun;

	public float firingSpeed = 50f;
	public float decaySeconds = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {
			GameObject bullet = Instantiate (fruit, gun.transform.position,gun.transform.rotation,null) as GameObject;
			bullet.GetComponent<Rigidbody> ().AddForce (gun.transform.forward * firingSpeed, ForceMode.Impulse);
			Object.Destroy (bullet, decaySeconds);
		}

	}
}
