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
	void Start(){
		body = GetComponent<Rigidbody2D> ();
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			StartCoroutine(KnockBack (other.transform.position, 0.2f));
			if (!other.gameObject.GetComponent<EnergyBallCreation> ().ballSpawned) {
				Vector3 pos = new Vector3 (((other.transform.position.x - transform.position.x)/ 2) + transform.position.x, transform.position.y, 0f);
				GameObject energyBall = energyBalls.Recycle (pos, Quaternion.identity);
				energyBall.GetComponent<Killer> ().enabled = false;
				ballSpawned = true;
				StartCoroutine(MakeDamage(timeToDamage,energyBall));
			}
		}
	}
	IEnumerator MakeDamage(float time,GameObject ball){
		float timer = 0;
		while (timer < time) {
			timer += Time.deltaTime;
		}
		if (timer >= time) {
			ballSpawned = false;
			ball.GetComponent<Killer> ().enabled = true;
		}
		yield return 0;
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
