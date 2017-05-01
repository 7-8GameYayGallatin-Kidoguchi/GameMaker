using UnityEngine;

[System.Serializable]
public class CombatStat : System.Object {

	[Header("Health Modifiers")]
	public float maxHealth = 0f;
	public float health = 0f;

	[Header("Damage Modifiers")]
	public float dmgBase = 0f; // Power - Damage base , also Knockback base
	public float dmgRange = 0f; // Control - Damage range
	public float critChance = 0f; // Reliability - Chance to multiply by critPower
	public float critPower = 1f;
	public bool isAttacking = false;

	[Header("Defense Modifiers")]
	public float defense = 0f;
	public bool isAttackable = true;

	public float dmgCalc(){
		float hit = (dmgBase + Random.Range(-dmgRange,dmgRange));	//hit is the dmgBase modified by a random amount within the range of dmgRange 
		if (Mathf.Ceil(Random.Range(1f,critChance)) == critChance) {				//roll a [critChange] sided die, if you get the max:
				hit = hit * critPower;								//multiply previous hit amount by critPower
		}															//Knockback is dmgBase
		hit = Mathf.Floor(hit);
		Debug.Log(hit);
		return hit;
	}

	public void applyDmg(float dmg){
		health -= dmg;
	}

}
