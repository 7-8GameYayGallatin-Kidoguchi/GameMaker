using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

	public Vector3 rotOffset = new Vector3 (0, 0, 0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.LookAt (Camera.main.transform.position);
		gameObject.transform.Rotate (rotOffset);
	}
}
