using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipTape : MonoBehaviour {
	public enum Direction{
		Left,Right
	}
	public Direction direction;
	public float slipForce;
	[SerializeField]
	List<Rigidbody2D> bodies = new List<Rigidbody2D> ();

	void Update(){
		foreach (Rigidbody2D body in bodies) {
			body.AddForce (Vector3.right * slipForce * (direction == Direction.Right?1:-1));
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		Rigidbody2D body = other.GetComponent<Rigidbody2D> ();
		bodies.Add (body);
	}
	void OnTriggerExit2D(Collider2D other){
		Rigidbody2D body = other.GetComponent<Rigidbody2D> ();
		bodies.Remove (body);
	}
}
