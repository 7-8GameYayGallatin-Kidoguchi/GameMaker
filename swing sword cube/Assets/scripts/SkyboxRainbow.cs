using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkyboxRainbow : MonoBehaviour {

	private float r = 1;
	private float g = 0;
	private float b = 0;

	public Camera mainCamera;
	public Light sun;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (g <= .5f && b >= 1f)
			r = r + .0025f; // up: g is 0, b is 255 ; down: g is 255, b is 0
		else if (g >= 1f && b <= .5f)
			r = r - .0025f;

		if (r >= 1f && b <= .5f)
			g = g + .0025f; // up: r is 255, b is 0 ; down: r is 0, b is 255
		else if (r <= .5 && b >= 1f)
			g = g - .0025f;

		if (r <= .5f && g >= 1f)
			b = b + .0025f; // up: r is 0, g is 255 ; down: r is 255, g is 0
		else if (r >= 1f && g <= .5f)
			b = b - .0025f;

		if (r < .5f)
			r = .5f;
		if (r > 1f)
			r = 1f;
		if (g < .5f)
			g = .5f;
		if (g > 1f)
			g = 1f;
		if (b < .5f)
			b = .5f;
		if (b > 1f)
			b = 1f;

		mainCamera.backgroundColor = new Color (r, g, b);
		sun.color = new Color (r, g, b);

	}
}
