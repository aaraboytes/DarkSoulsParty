using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour {
	public List<Player>players = new List<Player>();
	[SerializeField]
	Transform target;
	Rigidbody2D bomb;
	[Header("Bomb setup")]
	public float timeToExplode;
	float timer;
	public Text timerText;
	[SerializeField]
	GameObject explosive;
	CircleCollider2D explosiveCircle;
	public float speed;
	public float rotateSpeed;
	public float radius;
	[SerializeField]
	Pool explosionPool;

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
	void Start () {
		foreach (Player p in players) {
			if (!p.isActiveAndEnabled) {
				players.Remove (p);
			}
		}
		SetNewTarget ();
		bomb = GetComponent<Rigidbody2D> ();
		explosiveCircle = explosive.GetComponent<CircleCollider2D> ();
		explosiveCircle.radius = radius;
	}
	void Update(){
		if (target == null)
			SetNewTarget ();
		timer += Time.deltaTime;
		timerText.text = ((int)timeToExplode-(int)timer).ToString();
		if (timer > timeToExplode) {
			Explode ();
			CheckAlivePlayers ();
			SetNewTarget ();
			Invoke ("TurnOffExplosion", 0.2f);
			timer = 0;
		}
	}
	void FixedUpdate () {
		if (players.Count > 0) {
			Vector2 direction = (Vector2)target.position - bomb.position;
			direction.Normalize ();
			bomb.velocity = direction * speed;
			float rotation = Vector3.Cross (direction, transform.up).z;
			bomb.angularVelocity = -rotation * rotateSpeed;
			bomb.velocity = transform.up * speed;
		}
	}
	void Explode(){
		explosionPool.Recycle (bomb.position, Quaternion.identity);
		explosive.SetActive (true);
	}
	void CheckAlivePlayers(){
		foreach (Player p in players) {
			if (!p.isActiveAndEnabled)
				players.Remove (p);
		}
	}
	void SetNewTarget(){
		speed += 10;
		target = players [Random.Range (0, players.Count-1)].transform;
	}
	void TurnOffExplosion(){
		explosive.SetActive (false);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player") && other.transform != target) {
			target = other.transform;
		}
	}
}
