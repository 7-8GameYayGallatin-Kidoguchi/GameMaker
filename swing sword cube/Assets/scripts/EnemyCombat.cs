using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour {

	public CombatStat stats;

	public SphereCollider hitbox;
	List<GameObject>targettable = new List<GameObject>();

	public GameObject target;

	// Use this for initialization
	void Start () {
		stats.health = stats.maxHealth;
		hitbox = GetComponent<SphereCollider> ();
	}

	void OnTriggerExit (Collider other){
		if (other.CompareTag ("player")) {
			targettable.Remove (other.gameObject);
			Debug.Log ("removed");
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.CompareTag ("player")) {
			targettable.Add (other.gameObject);
			Debug.Log ("added");
		}
	}

	// Update is called once per frame
	void Update () {
		if (stats.health <= 0) {
			stats.isAttackable = false;


		}


		Vector3 location = target.transform.position;

		location += new Vector3 (0f, 1.25f, 0f);

		gameObject.transform.LookAt (location);
	}

	void Melee(CombatStat attackStat)
	{
		Vector3 pos = transform.position;
		for(int i = 0; i < targettable.Count;i++)
		{
			Vector3 vec = targettable[i].transform.position;
			Vector3 direction = vec - pos;
			if(Vector3.Dot(direction, transform.forward)<1){
				if (targettable [i].GetComponent <EnemyCombat> ().stats.isAttackable) {
					float dmg = attackStat.dmgCalc();
					targettable [i].GetComponent <EnemyCombat> ().stats.applyDmg (dmg);
				}
			}
		}
	}

}
