using UnityEngine;
using System.Collections;

public class SphereRot : MonoBehaviour {

	public Camera mainCamera;
	public Light mainLight;

	public float Speed;

	private Rigidbody rb;

	private float xMove;
	private float zMove;

	private float SunDirection;

	/*public static float FindDegree(float x, float y){
		float value = (Mathf.Atan2(x, y) / Mathf.PI) * 180;
		if(value < 0f) value += 360f;
		return (float)value;
	}*/

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		xMove = 0;
		zMove = 0;
		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {

			xMove = Input.GetAxis ("Horizontal");
			zMove = Input.GetAxis ("Vertical");

			//Terrain.activeTerrain.SampleHeight(transform.position)+.5f
			//transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x + xMove, transform.position.y, transform.position.z + zMove), Speed);

			Vector3 movement = new Vector3 (xMove, 0.0f, zMove);
			rb.AddForce (movement * (Speed*Time.deltaTime), ForceMode.VelocityChange);

			//transform.Rotate(new Vector3(zMove, 0f, xMove));

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