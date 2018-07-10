using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour {
	public float extraYPos;
	public float speed;
	Transform target;
	Rigidbody2D crown;

	void Start(){
		crown = GetComponent<Rigidbody2D> ();
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			CrownManager._instance.setCurrentPlayer (other.GetComponent<Player> ().prefixInput);
			target = other.transform;
		}
	}
	void FixedUpdate(){
		if(target!=null)
			crown.position = Vector2.Lerp (crown.position, (Vector2)target.position + (Vector2.up * extraYPos), speed * Time.deltaTime);
	}
}
