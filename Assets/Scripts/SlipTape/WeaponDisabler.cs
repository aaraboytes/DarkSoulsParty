using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisabler : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Weapon")) {
			other.gameObject.SetActive (false);
		}
	}
}
