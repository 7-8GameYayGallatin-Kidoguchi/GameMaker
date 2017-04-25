using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

	// returns the x and y coordinates for a rotation and a distance.
	private float LengthDir_X (float x, float dist, float dir) {
		return x+Mathf.Cos(dir*3.14f/180f)*dist;
	}
	private float LengthDir_Y (float y, float dist, float dir) {
		return y+Mathf.Sin(dir*3.14f/180f)*dist;
	}

	[Header("Camera")]
	public Camera mainCamera;
	public Transform shoulder;
	public bool shoulderCamera = false;

	[Header("Camera's Target")]
	public Transform target;
	public Vector3 targetOffset;

	[Header("Camera limits")]
	public float mouseSensitivity = 2.0f;
	public float upLimit = 60f;
	public float downLimit = -60f;
	public float camDist = 5.0f;

	private float camPitch = 0.0f; // Up, Down
	private float camYaw = 0.0f; // Left, Right

	public LayerMask camOcclusion;

	private RaycastHit hit;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;

		camYaw = target.eulerAngles.y + 180f;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		// Up and Down
		camPitch -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		camPitch = Mathf.Clamp (camPitch, downLimit, upLimit);

		// Left and Right
		camYaw += -Input.GetAxis ("Mouse X") * mouseSensitivity;
		if (camYaw >= 360) {
			camYaw = 0;
		} else if (camYaw < 0) {
			camYaw = 359;
		}

		mainCamera.transform.localPosition = new Vector3 (LengthDir_X(0,camDist,camYaw), LengthDir_Y(0,camDist,camPitch), LengthDir_Y(0,camDist,camYaw));

		//Vector3 castDir = transform.position - target.position;
		if (Physics.Linecast (target.position+targetOffset, mainCamera.transform.position, out hit, camOcclusion)) {
			mainCamera.transform.position = new Vector3 (hit.point.x, mainCamera.transform.position.y, hit.point.z);
		}
			
		//mainCamera.transform.localPosition = new Vector3 (LengthDir_X(0,camDist,camYaw), LengthDir_Y(0,camDist,camPitch), LengthDir_Y(0,camDist,camYaw));
		//mainCamera.transform.localRotation = Quaternion.Euler(camPitch, camYaw, 0);

		mainCamera.transform.LookAt(target.position+targetOffset);

	}
}