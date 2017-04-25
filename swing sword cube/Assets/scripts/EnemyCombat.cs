using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour {

	public CombatStat stats;

	public BoxCollider hitbox;

	public GameObject target;

	// Use this for initialization
	void Start () {
		stats.health = stats.maxHealth;
		//hitbox = GetComponent<BoxCollider> ();
	}

	void OnTriggerEnter (Collider other){
		if (stats.isAttackable) {
			if (other.CompareTag ("player")) {
				if (other.gameObject.GetComponent<PlayerCombat> ().stats.isAttacking) {
					stats.health -= other.gameObject.GetComponent<PlayerCombat> ().stats.dmgCalc ();
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {

		Vector3 location = target.transform.position;

		location += new Vector3 (0f, 1.25f, 0f);

		gameObject.transform.LookAt (location);
	}
}
