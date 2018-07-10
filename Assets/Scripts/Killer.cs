using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			Player player = other.GetComponent<Player> ();
			player.MakeDamage (100,transform.position);
		}
	}
}
