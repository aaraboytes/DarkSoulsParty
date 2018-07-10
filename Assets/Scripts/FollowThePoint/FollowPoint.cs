using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			FollowPointManager._instance.Goal(other.GetComponent<Player> ());
		}
	}
}
