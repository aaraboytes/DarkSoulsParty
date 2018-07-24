using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallCreation : MonoBehaviour {
	Rigidbody2D body;
	public float force;
	public Transform colliderChecker;
	public float colliderRadius;
	public LayerMask layerMask;
	void Start(){
		body = GetComponent<Rigidbody2D> ();
	}
	void OnDrawGizmosSelected(){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere (colliderChecker.position, colliderRadius);
	}
	void Update(){
		if (isColliding ()) {
			body.AddForce (Vector3.up * force);
		}
	}
	bool isColliding(){
		return Physics2D.OverlapCircle(colliderChecker.position,colliderRadius,layerMask);	
	}
}
