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
	public void setPlayerNum(int numOfPlayer){
		switch(numOfPlayer){
		case 1:
			playerNumber = InputController.PlayerNumber.One;
			break;
		case 2:
			playerNumber = InputController.PlayerNumber.Two;
			break;
		case 3:
			playerNumber = InputController.PlayerNumber.Three;
			break;
		case 4:
			playerNumber = InputController.PlayerNumber.Four;
			break;
		}
		prefixInput = InputController.GetPrefix (playerNumber);
	}
	void OnCollisionEnter(Collision collision){
		foreach (ContactPoint contact in collision.contacts) {
			if (contact.otherCollider.gameObject.CompareTag("Player")) {
				sphere.AddForce (((contact.point - transform.position) * -1 * knockBackForce) + Vector3.up * 5.0f, ForceMode.Acceleration);
			}
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
