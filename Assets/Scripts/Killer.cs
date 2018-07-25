using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour {
	public bool startKilling = false;
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			if (startKilling) {
				Player player = other.GetComponent<Player> ();
				player.MakeDamage (100, transform.position);
			}
		}
	}
}
