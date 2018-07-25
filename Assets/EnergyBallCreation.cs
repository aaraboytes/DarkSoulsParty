using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallCreation : MonoBehaviour {
	Rigidbody2D body;
	public float forceX,forceY;
	public bool ballSpawned = false;
	[SerializeField]
	private Pool energyBalls;
	public float timeToDamage = 0.2f;
	float timer = 0;
	private GameObject currentEnergyBall;
	void Start(){
		body = GetComponent<Rigidbody2D> ();
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			StartCoroutine(KnockBack (other.transform.position, 0.2f));
			if (!other.gameObject.GetComponent<EnergyBallCreation> ().ballSpawned) {
				Vector3 pos = new Vector3 (((other.transform.position.x - transform.position.x)/ 2) + transform.position.x, transform.position.y, 0f);
				currentEnergyBall = energyBalls.Recycle (pos, Quaternion.identity);
				ballSpawned = true;
			}
		}
	}
	void Update(){
		if (ballSpawned) {
			timer += Time.deltaTime;
			if (timer > timeToDamage) {
				currentEnergyBall.GetComponent<Killer> ().startKilling = true;
				currentEnergyBall = null;
				ballSpawned = false;
				timer = 0;
			}
		}
	}
	IEnumerator KnockBack(Vector3 collisionPoint,float time){
		float timer = 0;
		Vector3 dir = (collisionPoint - transform.position).normalized;
		while (timer < time) {
			timer += Time.deltaTime;
			body.AddForce (new Vector3(dir.x * -forceX,forceY,0f));
		}
		yield return 0;
	}
}
