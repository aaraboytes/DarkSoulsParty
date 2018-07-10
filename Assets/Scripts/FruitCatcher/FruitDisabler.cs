using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDisabler : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("item")) {
			other.gameObject.SetActive (false);
		}
	}
}
