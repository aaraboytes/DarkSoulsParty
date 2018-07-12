using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	Rigidbody sphere;
	public int life;
	public string prefixInput;
	public float speed;
	float vertical;
	float horizontal;
	public InputController.PlayerNumber playerNumber;
	public float knockBackForce;
	public bool alive = true;
	void Awake(){
		prefixInput = InputController.GetPrefix (playerNumber);
	}
	void Start () {
		sphere = GetComponent<Rigidbody> ();
	}
	void Update () {
		vertical = Input.GetAxis (prefixInput + "Vertical");
		horizontal = Input.GetAxis (prefixInput + "Horizontal");
		sphere.velocity = new Vector3 (horizontal * speed, sphere.velocity.y, vertical * speed);
	}
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			Vector3 knockBackDir = (other.transform.position - transform.position).normalized;
			sphere.AddForce (knockBackDir * knockBackForce + Vector3.up * 5.0f);
			Debug.Log ((knockBackDir * knockBackForce));
		}
	}
	public void MakeDamage(int damage){
		life -= damage;
		if (life <= 0) {
			gameObject.SetActive (false);
			alive = false;
		}
	}
}
