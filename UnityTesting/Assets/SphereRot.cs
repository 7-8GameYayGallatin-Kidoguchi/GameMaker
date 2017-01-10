using UnityEngine;
using System.Collections;

public class SphereRot : MonoBehaviour {

	public Camera mainCamera;
	public Light mainLight;

	public float Speed;

	private float xMove;
	private float yMove;

	private float SunDirection;

	/*public static float FindDegree(float x, float y){
		float value = (Mathf.Atan2(x, y) / Mathf.PI) * 180;
		if(value < 0f) value += 360f;
		return (float)value;
	}*/

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		xMove = 0;
		yMove = 0;
		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			print ("Movement!");

			xMove = Input.GetAxis ("Horizontal") * Speed * Time.deltaTime;
			yMove = Input.GetAxis ("Vertical") * Speed * Time.deltaTime;

			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x + xMove, transform.position.y, transform.position.z + yMove), Speed*Time.deltaTime);

			transform.Rotate(yMove*100, 0, xMove*-100, 0);

		} else {
			print ("No Movement.");
		}

		SunDirection = SunDirection+.05f;
		if (SunDirection == 360) {
			SunDirection = 0;
		}
		mainLight.transform.eulerAngles = new Vector3(SunDirection,20,20);

    }

	void LateUpdate() {
		mainCamera.transform.position = new Vector3 (transform.position.x, transform.position.y+2, transform.position.z - 10);
	}
}