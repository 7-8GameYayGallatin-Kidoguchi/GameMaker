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

	public GameObject textOutline;

	public SphereCollider hitbox;
	List<GameObject>targettable = new List<GameObject>();

	// Use this for initialization
	void Start () {
		stats.health = stats.maxHealth;
		anim = GetComponent<Animator> ();
		hitbox = GetComponent<SphereCollider> ();
	}

	void OnTriggerExit (Collider other){
		if (other.CompareTag ("enemy")) {
			targettable.Remove (other.gameObject);
			Debug.Log ("removed");
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.CompareTag ("enemy")) {
			targettable.Add (other.gameObject);
			Debug.Log ("added");
		}
		//if (stats.isAttackable) {
			//if (other.CompareTag ("enemy")) {
				//if (other.gameObject.GetComponent<EnemyCombat> ().stats.isAttacking) {
					//stats.health -= other.gameObject.GetComponent<EnemyCombat> ().stats.dmgCalc ();
				//}
			//}
		//}
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
		
		if (Input.GetButtonDown ("Fire2")) {
			//anim.SetTrigger ("isAttackingLeft");
			//stats.isAttacking = true;
			//Invoke("StopAttacking",.5f);
			if (leftWeapon != null) {
				Melee (leftWeapon.GetComponent<axe_control> ().stats);
			} else {
				Melee (stats);
			}

		}
		if (Input.GetButtonDown ("Fire1")) {
			//anim.SetTrigger ("isAttackingRight");
			if (rightWeapon != null) {
				Melee (rightWeapon.GetComponent<axe_control> ().stats);
			} else {
				Melee (stats);
			}
		}

		//healthbar.transform.LookAt (Camera.main.transform);
		//healthbar.GetComponent<Renderer> ().material.color = new Color (Mathf.Clamp (Mathf.Abs ((health / (maxHealth/2f)) - 2f), .5f, 1f),Mathf.Clamp (health / (maxHealth/2f), .5f, 1f),.5f);
		//draw_set_color(new Color32(255*(clamp(abs((hp/50)-2),0,1)),255*(clamp(hp/50,0,1)),0));

	}

	void StopAttacking(){
		stats.isAttacking = false;
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
					Vector3 textpos = transform.position;
					textpos.y+=2f;
					Instantiate (textOutline, textpos, Quaternion.identity).GetComponent<textFloat> ().text = dmg.ToString ();
				}
			}
		}
	}

}
