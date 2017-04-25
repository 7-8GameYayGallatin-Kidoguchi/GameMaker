using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum axe_tier{
	normal_full,normal_damaged1,normal_damaged2,silver_full,silver_damaged1,silver_damaged2,gold
}

public class axe_control : MonoBehaviour {

	public axe_tier current;

	public Texture normal;
	public Texture silver;
	public Texture gold;

	public GameObject full;
	public GameObject damaged1;
	public GameObject damaged2;
	public GameObject handle;

	public CombatStat stats;

	// Use this for initialization
	void Start () {

		if (current == axe_tier.normal_full) {
			full.SetActive (true);
			full.GetComponent<Renderer> ().material.mainTexture = normal; 
			handle.GetComponent<Renderer> ().material.mainTexture = normal; 

			damaged1.SetActive (false);
			damaged2.SetActive (false);

			stats.dmgBase = 5f;
			stats.dmgRange = 5f;
			stats.critChance = 10f;
			stats.critPower = 1.5f;

		} else if (current == axe_tier.normal_damaged1) {
			damaged1.SetActive (true);
			damaged1.GetComponent<Renderer> ().material.mainTexture = normal;
			handle.GetComponent<Renderer> ().material.mainTexture = normal; 

			full.SetActive (false);
			damaged2.SetActive (false);

			stats.dmgBase = 5f;
			stats.dmgRange = 5f;
			stats.critChance = 15f;
			stats.critPower = 1.5f;

		} else if (current == axe_tier.normal_damaged2) {
			damaged2.SetActive (true);
			damaged2.GetComponent<Renderer> ().material.mainTexture = normal;
			handle.GetComponent<Renderer> ().material.mainTexture = normal; 

			full.SetActive (false);
			damaged1.SetActive (false);

			stats.dmgBase = 5f;
			stats.dmgRange = 5f;
			stats.critChance = 20f;
			stats.critPower = 1.5f;

		} else if (current == axe_tier.silver_full) {
			full.SetActive (true);
			full.GetComponent<Renderer> ().material.mainTexture = silver; 
			handle.GetComponent<Renderer> ().material.mainTexture = silver;

			damaged1.SetActive (false);
			damaged2.SetActive (false);

			stats.dmgBase = 10f;
			stats.dmgRange = 5f;
			stats.critChance = 10f;
			stats.critPower = 2f;

		} else if (current == axe_tier.silver_damaged1) {
			damaged1.SetActive (true);
			damaged1.GetComponent<Renderer> ().material.mainTexture = silver;
			handle.GetComponent<Renderer> ().material.mainTexture = silver;

			full.SetActive (false);
			damaged2.SetActive (false);

			stats.dmgBase = 10f;
			stats.dmgRange = 5f;
			stats.critChance = 15f;
			stats.critPower = 2f;

		} else if (current == axe_tier.silver_damaged2) {
			damaged2.SetActive (true);
			damaged2.GetComponent<Renderer> ().material.mainTexture = silver; 
			handle.GetComponent<Renderer> ().material.mainTexture = silver;

			full.SetActive (false);
			damaged1.SetActive (false);

			stats.dmgBase = 10f;
			stats.dmgRange = 5f;
			stats.critChance = 20f;
			stats.critPower = 2f;

		} else { //Gold (never broken!)
			full.SetActive (true);
			full.GetComponent<Renderer> ().material.mainTexture = gold;
			handle.GetComponent<Renderer> ().material.mainTexture = gold;

			damaged1.SetActive (false);
			damaged2.SetActive (false);

			stats.dmgBase = 20f;
			stats.dmgRange = 5f;
			stats.critChance = 10f;
			stats.critPower = 2.5f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
