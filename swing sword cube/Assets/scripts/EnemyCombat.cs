using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour {

	public CombatStat stats;

	public BoxCollider hitbox;

	// Use this for initialization
	void Start () {
		hitbox = GetComponent<BoxCollider> ();
	}

	void OnTriggerEnter (Collider other){
		if (other.CompareTag ("player")) {
			//if (other.gameObject.CombatStats.isAttacking) {
			//stats.health -= other.gameObject.CombatStats.dmgCalc();
			//}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
