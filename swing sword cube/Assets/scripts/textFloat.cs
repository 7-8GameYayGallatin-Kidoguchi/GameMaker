using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textFloat : MonoBehaviour {

	public string text;
	//public Color border;
	//public Color inside;

	// Use this for initialization
	void Start () {
		transform.Find ("border").GetComponent<TextMesh> ().text = text;
		transform.Find ("bg").GetComponent<TextMesh> ().text = text;
		//transform.Find ("border").GetComponent<TextMesh> ().color = border;
		//transform.Find ("bg").GetComponent<TextMesh> ().color = inside;
		Destroy(gameObject,2f);
	}

	void Update(){
		Vector3 pos = transform.position;
		pos.y+=.03f;
		transform.position = pos;
	}
}
