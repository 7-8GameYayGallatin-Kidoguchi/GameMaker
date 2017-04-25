using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

	public CombatStat stats;

	[Header("Equip")]
	public Transform rightHand;
	public Transform rightWeapon;
	public Transform leftHand;
	public Transform leftWeapon;

	public GameObject healthbar;

	static Animator anim;

	public BoxCollider hitbox;

	// Use this for initialization
	void Start () {
		stats.health = stats.maxHealth;
		anim = GetComponent<Animator> ();
		hitbox = GetComponent<BoxCollider> ();
	}

	void OnTriggerEnter (Collider other){
		if (stats.isAttackable) {
			if (other.CompareTag ("enemy")) {
				if (other.gameObject.GetComponent<EnemyCombat> ().stats.isAttacking) {
					stats.health -= other.gameObject.GetComponent<EnemyCombat> ().stats.dmgCalc ();
				}
			}
		}
		if (rightWeapon==null) {
			if (other.CompareTag ("weapon") & other.gameObject.transform!=leftWeapon) {
				rightWeapon = other.gameObject.transform;
				rightWeapon.parent = rightHand;

				rightWeapon.localPosition = Vector3.zero;
				rightWeapon.localRotation = new Quaternion (0, 0, 0, 0);
			}
		}
		else if (leftWeapon==null) {
			if (other.CompareTag ("weapon") & other.gameObject.transform!=rightWeapon) {
				leftWeapon = other.gameObject.transform;
				leftWeapon.parent = leftHand;

				leftWeapon.localPosition = Vector3.zero;
				leftWeapon.localRotation = new Quaternion (0, 0, 0, 0);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown ("Fire1")) {
			anim.SetTrigger ("isAttackingLeft");

		}
		if (Input.GetButtonDown ("Fire2")) {
			anim.SetTrigger ("isAttackingRight");
		}

		//healthbar.transform.LookAt (Camera.main.transform);
		//healthbar.GetComponent<Renderer> ().material.color = new Color (Mathf.Clamp (Mathf.Abs ((health / (maxHealth/2f)) - 2f), .5f, 1f),Mathf.Clamp (health / (maxHealth/2f), .5f, 1f),.5f);
		//draw_set_color(new Color32(255*(clamp(abs((hp/50)-2),0,1)),255*(clamp(hp/50,0,1)),0));

	}

}
