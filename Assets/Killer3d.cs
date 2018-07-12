using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer3d : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			other.GetComponent<BallController> ().MakeDamage (100);
		}
	}
}
