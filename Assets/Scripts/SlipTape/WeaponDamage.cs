using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour {
	public int damage;
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			other.GetComponent<Player> ().MakeDamage (damage,transform.position);
		}
	}
}
