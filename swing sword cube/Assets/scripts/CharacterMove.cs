using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMove : MonoBehaviour {

	private CharacterController controller;
	private Animator animator;
	public GameObject character;
	private Camera mainCamera;

	public float movementSpeed = 5.0f;
	public float jumpHeight = 5.0f;
	public float localGrav = -9.81f;

	private float velocity = 0.0f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator> ();
		mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Jumping
		if (controller.isGrounded) {
			if (Input.GetButtonDown ("Jump")) {
				velocity = jumpHeight;
			}
		} else {
			velocity += localGrav * Time.deltaTime;
		}

		//Movement
		float forwardMove = Input.GetAxis ("Vertical") * movementSpeed;
		float strafeMove = Input.GetAxis ("Horizontal") * movementSpeed;

		Vector3 speed = new Vector3 (strafeMove, velocity, forwardMove);
		speed = Quaternion.AngleAxis (mainCamera.transform.rotation.eulerAngles.y, new Vector3 (0, 1, 0)) * speed;

		controller.Move (speed * Time.deltaTime);

		//Character Orientation
		if (strafeMove != 0 || forwardMove != 0) { //Character faces the direction it moves relative to the camera

			Quaternion angle = Quaternion.LookRotation (new Vector3 (speed.x, 0, speed.z), Vector3.up);
			character.transform.rotation = angle;

			animator.SetBool ("isWalking", true);
			animator.speed = movementSpeed * .4f;

		} else {
			animator.SetBool ("isWalking", false);
			animator.speed = 1;
		}

	}
}